     public partial class MainPage : UserControl
        {
            private Thread _thread1;
    
            public MainPage()
            {
                InitializeComponent();
            }
    
            private void StartThreads()
            {
                _thread1 = new Thread(test1);
                _thread1.Start();
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                busyIndicator1.IsBusy = true;
                StartThreads();
            }
    
            private void test1()
            {
                for (int i = 1; i < 10000; i++)
                {
                    System.Diagnostics.Debug.WriteLine(i.ToString());
                }
                this.Dispatcher.BeginInvoke(delegate()
                {
                    textBox1.Text = "test";
                    busyIndicator1.IsBusy = false;
                });
            }
        }
