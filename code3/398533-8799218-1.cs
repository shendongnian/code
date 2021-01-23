     public partial class Welcome : UserControl
        {
            public Welcome()
            {
                InitializeComponent();
            }
    
            public string ClientName
            {
                get 
                {
                    return txtClientName.Text;
                }
                set
                {
    
                    txtClientName.Text = value;
    
                }
            }
        }
