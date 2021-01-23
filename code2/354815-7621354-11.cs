    using System.Windows;
    using System.Windows.Media.Animation;
    using System.Windows.Media;
    using System;
    
    namespace Sample    {
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
    
            }
    
            private void btnClick_Click(object sender, RoutedEventArgs e)
            {
                Storyboard sb = this.Resources["Storyboard"] as Storyboard;
                if (sb != null)
                {
                    ColorAnimation frame = sb.Children[0] as ColorAnimation;
                    Random rand = new Random();
                    Color col = new Color()
                                  {
                                      A = 100,
                                      R = (byte)(rand.Next() % 255),
                                      G = (byte)(rand.Next() % 255),
                                      B = (byte)(rand.Next() % 255)
                                  };
                    frame.To = col;
                    sb.Begin();
                }
            }
        }
    
    
    }
