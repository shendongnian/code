       private bool mbIsRunning = true;
    
       private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
       {
          lock (this)
          {
             mbIsRunning= false;
          }
       }
    
       private bool IsRunning
       {
            get
            { 
                lock(this)
                {
                    return mbIsRunning;
                }
            }
        }
    
    
        string msg;
        public void Reader(object o)
        {
    
            TcpClient con = o as TcpClient;
            if (con == null)
                return;
            while (IsRunning)
            {
                 msg = reader.ReadLine(); 
                 string line;
                 while( (line = reader.ReadLine()) != null )
                 {
                    msg = msg + Enviroment.NewLine + line;
                 }
    
                 Invoke(new Action(Output));
            }
        }
