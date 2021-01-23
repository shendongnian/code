    System.Timers.Timer Auto_Timer = new System.Timers.Timer();
     Auto_Timer.Elapsed += new System.Timers.ElapsedEventHandler(Auto_Timer_Elapsed);
     Auto_Timer.Interval = (3*3600000); //3 hours time
     Auto_Timer.Enabled = true;
     void Auto_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
     {
         writetolog(Message);
     }
