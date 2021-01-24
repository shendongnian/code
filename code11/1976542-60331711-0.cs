      public partial class Page1 : Page
        {
            public Page1()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                
                Application.Current.Windows[0].Width = 100;
                Application.Current.Windows[0].Height = 100;
             
       
            }
        }
