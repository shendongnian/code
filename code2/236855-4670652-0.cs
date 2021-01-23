     private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
              if (e.Clicks < 2) //not a doubleclick
              {
                  this.notifyIcon.BalloonTipText = "Some Info";
                  this.notifyIcon.ShowBalloonTip(1000);
              }
            }
        }
