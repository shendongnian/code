        {
            if (e.Reason == SessionSwitchReason.SessionLock)
             
             
            {
             System.Threading.Thread.Sleep(500);
             CommunicatorAPI.MessengerClass comm=new  CommunicatorAPI.MessengerClass();
             
             if(comm.MyStatus==MISTATUS.MISTATUS_AWAY)
            
             {
              
                   
                           SetMyPresence1 ();
             }
             
              else if (e.Reason == SessionSwitchReason.SessionUnlock)
              
            {
             ChangeStatus1 ();
            }
            }
