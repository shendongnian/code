    public static void ShowBalloon(string title, string body)
    {
        // Show with icon
        NotifyIcon ni = new NotifyIcon() { Visible = true, Icon = Properties.Resources.Icon};
        // Timeout is deprecated since Vista
        ni.ShowBalloonTip(0, title, body, ToolTipIcon.None);
        // Dispose on event
        ni.BalloonTipClosed += (sender, e) => ni.Dispose();
    }
