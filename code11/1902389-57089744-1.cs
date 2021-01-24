    private Register regis;
    
    public void Open()
    {
        Application.Current.MainWindow.Hide();
        
        // Create the register window, if it doesn't exist
        if (regis == null)
        {
            regis = new Register();
        }
        regis.Show();
    }
    
    public void Back()
    {
        // hide the register window, if it exists
        if (regis != null)
        {
            regis.Hide();
        }
        Application.Current.MainWindow.Show();
    }
