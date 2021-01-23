       for(int i = 0;i<10;i++)
       {   
         thread = new Thread(new ThreadStart(Get_CR_Information));
             thread.IsBackground = true;
              thread.Start();
            WaitHandle[] AWait = new WaitHandle[] { new AutoResetEvent(false) };
            while ( thread.IsAlive)
            {
                WaitHandle.WaitAny(AWait, 50, false);
                System.Windows.Forms.Application.DoEvents();
            } 
        }
