    private void InitializeTimer()  
    {  
        // Call this procedure when the application starts.  
        // Set to 1 second.  
        Timer1.Interval = 1000;  
        Timer1.Tick += new EventHandler(Timer1_Tick);  
      
        // Enable timer.  
        Timer1.Enabled = true;  
      
        Button1.Text = "Stop";  
        Button1.Click += new EventHandler(Button1_Click);  
    }  
      
    private void Timer1_Tick(object Sender, EventArgs e)     
    {  
       // Set the caption to the current time.  
       Label1.Text = DateTime.Now.ToString();  
    }  
      
    private void Button1_Click(object sender, EventArgs e)  
    {  
      if ( Button1.Text == "Stop" )  
      {  
        Button1.Text = "Start";  
        Timer1.Enabled = false;  
      }  
      else  
      {  
        Button1.Text = "Stop";  
        Timer1.Enabled = true;  
      }  
    }  
