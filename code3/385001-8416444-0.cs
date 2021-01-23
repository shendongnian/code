    public class NotificationHelper 
    {
        private readonly object notifyIconLock = new object();
        private TaskbarIcon notifyIcon { get; set; }      
        
        public NotificationHelper()     
        {         
            Thread thread = new Thread(OnLoad);         
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA         
            thread.Start();
        }
        
        public void ShowNotification(string text)
        {
            lock (notifyIconLock)
            {
                if (notifyIcon != null)
                {
                    notifyIcon.ShowBalloonTip("Demo", text, notifyIcon.Icon);
                }
            }
        }
        
        public void OnLoad()
        {
            lock (notifyIconLock)
            {
                notifyIcon = new TaskbarIcon();
                notifyIcon.Icon =
                    new Icon(@".\Icon\super-man-icon.ico");
                //notifyIcon.ToolTipText = "Left-click to open popup";
                notifyIcon.Visibility = Visibility.Visible;
            }
        }
        
        private void ShowBalloon()
        {
            lock (notifyIconLock)
            {
                if (notifyIcon != null)
                {
                    notifyIcon.ShowBalloonTip("Demo", Message, notifyIcon.Icon);
                }
            }
        }
    }
