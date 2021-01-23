    public class MyControl : UserControl
    {
        public Form form = null;
    
        public MyControl()
        {
            InitializeComponent();
    
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }
    
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                form.Close();
            }
        }
    }
