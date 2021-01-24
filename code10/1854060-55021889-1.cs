    using System.Windows;
    using System.Windows.Controls;
    
    namespace Test
    {
        /// <summary>
        /// Логика взаимодействия для MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                if (Grid.ColumnDefinitions[1].ActualWidth < MiddleUserControl.ActualWidth + 40)
                {
                    Grid.SetRow(MiddleUserControl, 1);
                    MiddleUserControl.Margin = new Thickness(0, 20, 0, 0);
                }
                else
                {
                    Grid.SetRow(MiddleUserControl, 0);
                    MiddleUserControl.Margin = new Thickness(0);
                }
            }
        }
    }
