     public Form1()
     {
         InitializeComponent();
        
         timer = new Timer();
         timer.Interval = 1000; // this is every second
         timer.Enabled = true;
         timer.Tick += timer_Tick;  // Ties the function below to the Tick event of the timer
         timer.Start(); // starts the timer, it will fire its tick even every interval
     }
     // these needs to go here so they are in class scope
     Timer timer; 
     DateTime dt1 = new DateTime(2019, 7, 12, 0, 29, 0);
            
     public void timer_Tick(object sender, EventArgs e)
     { 
         if (dt1.AddMinutes(-1) > DateTime.Now)
         {
              MessageBox.Show("1 Minute left");
              timer.Stop();  // stop the timer so you dont see the same message box every second 
         }
     }
