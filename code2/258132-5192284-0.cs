    public static bool SetBalloonTip(string balloonTipTitle, string balloonTipText, ToolTipIcon balloonTipIcon)
        {
            bool result = false;
            NotifyIcon notifyIcon;
            try
            {
                if (components == null)
                {
                    components = new System.ComponentModel.Container();
                }
                notifyIcon = new NotifyIcon(components);
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.BalloonTipTitle = balloonTipTitle;
                notifyIcon.BalloonTipText = balloonTipText;
                notifyIcon.BalloonTipIcon = balloonTipIcon;
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(30000);
                result = true;
            }
            catch (Exception)
            {
                
                throw;
            }
            return result;
        }
