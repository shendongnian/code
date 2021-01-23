    SystemEvents.SessionSwitch += new SessionSwitchEventHandler((sender, e) =>
            {
                switch (e.Reason)
                {
                    //If Reason is Lock, Turn off the monitor.
                    case SessionSwitchReason.SessionLock:
                        //SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF);
                        MessageBox.Show("locked");
                        break;
    
                    case SessionSwitchReason.SessionUnlock:
                        MessageBox.Show("unlocked");
                        break;
                }
            });
