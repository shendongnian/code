    if (DateTime.Now.Hour == 13 && DateTime.Now.Minute == 00 || DateTime.Now.Hour == 21 && DateTime.Now.Minute == 00)
    {
        var notification = new System.Windows.Forms.NotifyIcon()
        {
            Visible = true,
            Icon = System.Drawing.SystemIcons.Information,
            BalloonTipText = "This is my notify icon",
        };
        notification.ShowBalloonTip(1000);
    }
