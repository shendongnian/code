    /// <summary>   
    /// /// Interaction logic for MainWindow.xaml   
    /// /// </summary>    
    public partial class MainWindow : Window
    {
        //private delegate void AddListItem(int item);     
        Thread t;
        private long num = 3;
        private bool interrupt = true;
        private bool NotAPrime = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddListBoxItem(int item)
        {
            lbPrimes.Dispatcher.BeginInvoke
                (DispatcherPriority.Send,
                new Action(delegate()
                {
                    lbPrimes.Items.Add(item.ToString());
                }));
        }
        private void btss_Click(object sender, RoutedEventArgs e)
        {
            if (!interrupt)
            {
                interrupt = true;
                btss.Content = "Resume";
            }
            else
            {
                interrupt = false;
                btss.Content = "Stop";
                btss.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action(calculate));
            }
        }
        public void calculate()
        {
            NotAPrime = false;
            for (long i = 3; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    NotAPrime = true;
                    break;
                }
            }
        
            if (!NotAPrime)
            {
                lbPrimes.Items.Add(num.ToString());
            }
            num += 2;
            if (!interrupt)
            {
                btss.Dispatcher.BeginInvoke(
                     System.Windows.Threading.DispatcherPriority.SystemIdle,
                     new Action(this.calculate));
            }
        }
    }
