    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace TaskLoading
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public void bigProcess(){
                Thread.Sleep(5000);
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                imgLoading.Visibility = Visibility.Visible; //Make the icon visible.
    
                /* Start the bigProcess in a background thread: */
                Task changeIcon = Task.Factory.StartNew(() => 
                    {
                        bigProcess();
                    });
    
                /* At the end of the process make invisible the icon */
                changeIcon.ContinueWith((r) =>
                {
                    imgLoading.Visibility = Visibility.Hidden;
                    
                },
                    TaskScheduler.FromCurrentSynchronizationContext()
                );
            }
        }
    }
