    public partial class Window1 : Window
    {
    
        private bool SecondWindowOpen = false;
        private Window2 window2;
    
        public Window1()
        {
            InitializeComponent();
        }
    
        private void OpenSecondWindow_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindowOpen == false)
            {
                window2 = new Window2();
                window2.Visibility = Visibility.Visible;
                this.SecondWindowOpen = true;
            }
            else
            {
                //do whatever you want with window2, like window2.Close();
                //or window2.Visibility = Visibility.Hidden;
            }
        }
    }
