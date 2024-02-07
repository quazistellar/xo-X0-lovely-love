using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace krestiki_nolicki
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        Button[] buttons;
        bool starting = false;
        int game = 0;

        public MainWindow()
        {
            
            InitializeComponent();

            Title = "tic-tac-toe";
    
            buttons = new Button[] {_1, _2, _3, _4, _5, _6, _7, _8, _9};
            textik.Text = "'TIC-TAC-TOE' GAME";

            if (starting == false)
            {
                _1.IsEnabled = false;
                _2.IsEnabled = false;
                _3.IsEnabled = false;
                _4.IsEnabled = false;
                _5.IsEnabled = false;
                _6.IsEnabled = false;
                _7.IsEnabled = false;
                _8.IsEnabled = false;
                _9.IsEnabled = false;
            }

        }

        private void active_buttons()
        {
            _1.IsEnabled = true;
            _2.IsEnabled = true;
            _3.IsEnabled = true;
            _4.IsEnabled = true;
            _5.IsEnabled = true;
            _6.IsEnabled = true;
            _7.IsEnabled = true;
            _8.IsEnabled = true;
            _9.IsEnabled = true;
        }

        private void first_robot_moveX()
        {
            win();
            int robotMove = rand.Next(0, 9);
            win();
            buttons[robotMove].Content = "X";
            buttons[robotMove].IsEnabled = false;
        }

        private void robot1()
        {
            win();
            int knopka = rand.Next(0, 9);
            win();
            while (!buttons[knopka].IsEnabled)
            {
                win();
                knopka = rand.Next(0, 9);

                win();
                bool allButtonsAreFull = true;

                for (int i = 0; i < buttons.Length; i++)
                {
                    win();
                    if (buttons[i].IsEnabled)
                    {
                        win();
                        allButtonsAreFull = false;
                        break;
                    }
                }
                if (allButtonsAreFull)
                {
                    win();
                    ura_pobeda();
                    return;
                }
            }

            win();
            buttons[knopka].Content = "0";
            win();
            buttons[knopka].IsEnabled = false;
        }


        private void robot2()
        {
            win();
            bool allButtonsAreFull = true;
            win();
            for (int i = 0; i < buttons.Length; i++)
            {
                win();
                if (buttons[i].IsEnabled)
                {
                    win();
                    allButtonsAreFull = false;
                    break;
                }
            }

            if (allButtonsAreFull)
            {
                win();
                ura_pobeda();
                return;
            }

            int robotMove = rand.Next(0, 9);
          
            while (!buttons[robotMove].IsEnabled)
            {
                win();
                robotMove = rand.Next(0, 9);
                win();
            }

            buttons[robotMove].Content = "X";
            win();
            buttons[robotMove].IsEnabled = false;

            allButtonsAreFull = true;

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].IsEnabled)
                {
                    win();
                    allButtonsAreFull = false;
                    break;
                }
            }

            if (allButtonsAreFull)
            {
                win();
                ura_pobeda();
                return;
            }
        }

        private void start_game_click(object sender, RoutedEventArgs e)
        {
            flazhok = false;
            game++;

            foreach (Button button in buttons)
            {
                button.Content = null;
            }

       
            if (!(game % 2 == 0))

            {
                win();
                textik.Text = ">game has started< make ur move! ";
                active_buttons();

            }
             
            else if (game % 2 == 0)
            
            {
                win();
                active_buttons();
                textik.Text = ">game has started< robot makes its move! ";
                first_robot_moveX();
              
            } 
        }

        private void nazhali(object sender, RoutedEventArgs e)
        {

            if (!(game % 2 == 0))
            {
                win();
                if ((sender as Button).IsEnabled)
                {
                    (sender as Button).Content = "X";
                    (sender as Button).IsEnabled = false;
                    win(); 
                    if (!flazhok) 
                    {
                        win();
                        robot1();
                    }
                }
            }

            else if (game % 2 == 0)
            {
                win();
                if ((sender as Button).IsEnabled)
                {
                    (sender as Button).Content = "0";
                    (sender as Button).IsEnabled = false;
                    win(); 
                    if (!flazhok) 
                    {
                        win();
                        robot2();
                    }
                }
            }
        }

        private void ura_pobeda()
        {
          
            foreach (Button button in buttons)
            {
                //button.Content = null; - оно очищает кнопки сразу же после игры, но я решила оставить так,
                //чтобы после игры содержимое кнопок оставалось, а после рестарта очищалось

                button.IsEnabled = true; 
            }

            if (starting == false)
            {
                _1.IsEnabled = false;
                _2.IsEnabled = false;
                _3.IsEnabled = false;
                _4.IsEnabled = false;
                _5.IsEnabled = false;
                _6.IsEnabled = false;
                _7.IsEnabled = false;
                _8.IsEnabled = false;
                _9.IsEnabled = false;

            }
        }

        private bool flazhok = false;

        private void win()
        {
            if (winn("0"))
            {
                flazhok = true;
                ura_pobeda();
                textik.Text = "WIN OF NOLIKI";
           
            }

            if (winn("X"))
            {
                flazhok = true;
                ura_pobeda();
                textik.Text = "WIN OF KRESTIKI";
         
                
            }

            if (!winn("0") && !winn("X") && full_knopochki())
            {
               
                ura_pobeda();
                textik.Text = "POWER OF FRIENDSHIP";
     
               
            }
        }

        private bool winn(string symbol)
        {
            return ( ((string)_1.Content == symbol && (string)_2.Content == symbol && (string)_3.Content == symbol) ||
                    ((string)_4.Content == symbol && (string)_5.Content == symbol && (string)_6.Content == symbol) ||
                    ((string)_7.Content == symbol && (string)_8.Content == symbol && (string)_9.Content == symbol) ||
                    ((string)_1.Content == symbol && (string)_5.Content == symbol && (string)_9.Content == symbol) ||
                    ((string)_3.Content == symbol && (string)_5.Content == symbol && (string)_7.Content == symbol) ||
                    ((string)_1.Content == symbol && (string)_4.Content == symbol && (string)_7.Content == symbol) ||
                    ((string)_2.Content == symbol && (string)_5.Content == symbol && (string)_8.Content == symbol) ||
                    ((string)_3.Content == symbol && (string)_6.Content == symbol && (string)_9.Content == symbol));
        }

        private bool full_knopochki()
        {
            return !IsButtonContentEmpty(_1) && !IsButtonContentEmpty(_2) &&
                   !IsButtonContentEmpty(_3) && !IsButtonContentEmpty(_4) &&
                   !IsButtonContentEmpty(_5) && !IsButtonContentEmpty(_6) &&
                   !IsButtonContentEmpty(_7) && !IsButtonContentEmpty(_8) &&
                   !IsButtonContentEmpty(_9);
        }

        private bool IsButtonContentEmpty(Button button)
        {
            return button.Content == null || string.IsNullOrEmpty(button.Content.ToString());
        }
        private void cancel_game(object sender, RoutedEventArgs e)
        {

            if ((sender as Button).IsEnabled)
            {
                Environment.Exit(0);
            }
        }
    }
}