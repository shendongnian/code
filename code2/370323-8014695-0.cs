    foreach (Control ctl in this.Controls)
    {
       if (ctl is Button)
          (ctl as Button).Click += MyButtonHandler;
    }
    
    protected void MyButtonHandler(object sender, EventArgs e)
    {
      Button clickedButton = sender as Button;
      //...
    }
