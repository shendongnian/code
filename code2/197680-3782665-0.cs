    private void niTrayIcon_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            niTrayIcon.ContextMenuStrip = cmsTrayLeftClick;
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(niTrayIcon, null);
            niTrayIcon.ContextMenuStrip = cmsTrayRtClick;
        }
    }
