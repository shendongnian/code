        Point pntOnList = lsvSource.PointToClient
            (new Point(Cursor.Position.X, Cursor.Position.Y));
        ListViewItem lsviUnderMouse =
            lsvSource.GetItemAt(pntOnList.X, pntOnList.Y);
        if (lsviUnderMouse != null)
        {
            ttipDetails.SetToolTip(lsvSource, lsviUnderMouse.ToolTipText);
            ttipDetails.Active = true;
        }
        else
        {
            ttipDetails.Active = false;
        }
