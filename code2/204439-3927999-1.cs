    static void SystemEvents_SessionSwitch1(object sender, SessionSwitchEventArgs e)
    {
        if (e.Reason == SessionSwitchReason.SessionLock)
        {
            System.Threading.Thread.Sleep(500);
            CommunicatorAPI.MessengerClass comm = new CommunicatorAPI.MessengerClass();
            
            if (comm.MyStatus==MISTATUS.MISTATUS_AWAY)
            {
                SetMyPresence1 ();
            } else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                ChangeStatus1 ();
            }
        }
    }
