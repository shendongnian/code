    ...
    contextMenu.Popup += new EventHandler(contextMenu_Popup);
    ...
    private void trayIcon_IconClicked(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            //Do something here.
        }
        /* Only do this if you're not setting the trayIcon.ContextMenu property, 
        otherwise use the contextMenu.Popup event.
        else if(e.Button == MouseButtons.Right)
        {
            //Show uses assigned controls Client location to set position, 
            //so must go from screen to client coords.
            contextMenu.Show(this, this.PointToClient(Cursor.Position));
        }
        */
    }
    
    private void contextMenu_Popup(object sender, EventArgs e)
    {
        //Do something before showing the context menu.
    }
