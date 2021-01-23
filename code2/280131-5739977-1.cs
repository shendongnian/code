        Timer t = new Timer();
        
        t.Interval = 2000;
        
        timer1.Enabled = true;
        
        timer1.Tick += new System.EventHandler(OnTimerEvent);
        
    //You can use Tag property of your timer as userState
    
        void timer1_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            MyState state = timer.Tag  as MyState;
            int x = state.Value;
        }
