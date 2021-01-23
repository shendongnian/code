    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Thread(DoSomething).Start();
            new Thread(DoSomething2).Start();
        }
        public void DoSomething()
        {
            for (int i = 0; i < 100; i++)
            {
                Dispatcher.BeginInvoke(new Action(() => {
                    mtextBox.Text += $"{i.ToString()}{Environment.NewLine}";
                }), DispatcherPriority.SystemIdle);
                Thread.Sleep(100);
            }
            
        }
        public void DoSomething2()
        {
            for (int i = 100; i > 0; i--)
            {
                Dispatcher.BeginInvoke(new Action(() => {
                    mtextBox2.Text += $"{i.ToString()}{Environment.NewLine}";
                }), DispatcherPriority.SystemIdle);
                Thread.Sleep(100);
            }
        }
    }
