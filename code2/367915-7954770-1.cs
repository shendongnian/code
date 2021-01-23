    //In Form constructor function
    this.Closing += new EventHandler(Form1_Closing);
    
    private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
       //Handle event here
       System.Windows.Forms.Application.Exit();
    }
