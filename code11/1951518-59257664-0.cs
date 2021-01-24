            //draw rectangle behind the tabs
            Rectangle lastTabRect = SettingsTabControl.GetTabRect( SettingsTabControl.TabPages.Count - 1 );
            Rectangle background = new Rectangle();
            background.Location = new Point( lastTabRect.Right, 0 );
            //pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
            background.Size = new Size( SettingsTabControl.Right - background.Left, lastTabRect.Height + 1 );
            using (SolidBrush b = new SolidBrush( Colors.Get( Item.BorderBackground ) ))
            {
                e.Graphics.FillRectangle( b, background );
            }
