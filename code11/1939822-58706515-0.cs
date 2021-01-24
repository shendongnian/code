    namespace WpfApp2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private bool _nonUserChange = false;
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void a_TextChanged(object sender, TextChangedEventArgs e)
            {
                DoNonUserChange(() => b.Text = "bb");
            }
    
            private void b_TextChanged(object sender, TextChangedEventArgs e)
            {
                DoNonUserChange(() => c.Text = "cc");
            }
    
            private void DoNonUserChange(Action act)
            {
                if (act != null && !_nonUserChange)
                {
                    _nonUserChange = true;
                    act();
                    _nonUserChange = false;
                }
            }
        }
    }
