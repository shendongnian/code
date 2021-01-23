    private void ShowMessage(object sender, EventArgs e, string message)
    {
        MessageBox.Show(message);
    }
    public Form1()
    {
        InitializeComponent();
        myButton.Click += delegate(object sender, EventArgs e)   
        { 
            ShowMessage(sender,e,"You clicked my button!");
        };  
    }
