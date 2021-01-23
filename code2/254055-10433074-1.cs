    public YourForm()
    {
        InitializeComponent();
        try
        {
           //do some stuff + error occurs...
           //simulate error
           throw new exception("blah");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());               	
            Application.Exit(); //useless 
        }
	}
