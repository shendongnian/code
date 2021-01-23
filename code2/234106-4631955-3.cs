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
    using System.Threading.Tasks;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            // Dispatchers are an easy way to update the UI from a background thread
            private System.Windows.Threading.Dispatcher Dispatcher;
    
            // the Current Task - think of this as your background worker
            private Task CurrentTask;
    
    
            public MainWindow()
            {
                InitializeComponent();
    
                // this line needs to run on the main thread.
    
                Dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            }
    
            private void UpdateStatus(string msg)
            {
                // marshall the call back to the main thread
                Dispatcher.Invoke( new Action( () => TheLabel.Content = msg ));
            }
    
            // we're going to calculate the average of a sh*tload (technical term) of numbers
            private void DoSomeWork()
            {
                // update the UI
                UpdateStatus("Doing Work");
    
                Random r = new Random();
                int max = r.Next(100000000, 1000000000);
                double avg = Enumerable.Range(0, max).Average();
    
                // update the UI
                UpdateStatus(string.Format("Done - Average = {0}", avg));
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                // make sure the current task isn't already running
                if (CurrentTask != null && CurrentTask.IsCompleted == false)
                {
                    MessageBox.Show("Wait");
                    return;
                }
    
                // start a new one
                CurrentTask = Task.Factory.StartNew(() =>
                    {
                        DoSomeWork();
                    });
            }
        }
    }
