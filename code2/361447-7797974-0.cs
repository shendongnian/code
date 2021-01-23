    ...
    contextMenu.Popup += new EventHandler(contextMenu_Popup);
    ...
    private void trayIcon_IconClicked(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            //Do something here.
        }
    }
    
    private void contextMenu_Popup(object sender, EventArgs e)
    {
        //Do something before showing the context menu.
    }
