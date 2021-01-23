    public MainWindow()
            {
                InitializeComponent();
                AuthenticationWindow login = new AuthenticationWindow();
                login.ShowDialog();
                storedAuth = login.Result;
    
                if (storedAuth != null)
                {
                    // Making Deleting and Adding possible
                    // when file was opened.
                    tsmiOpen.Enabled = true;
                    tsmiNew.Enabled = true;
                }
    
               
            }
