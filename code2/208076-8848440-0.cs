    Point ResizeLocation = Point.Empty;
            void panResize_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left) {
                    ResizeLocation = e.Location;
                    ResizeLocation.Offset(-panResize.Width, -panResize.Height);
                    if (!(ResizeLocation.X > -16 || ResizeLocation.Y > -16))
                        ResizeLocation = Point.Empty;
                }
                else
                    ResizeLocation = Point.Empty;
            }
            void panResize_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left && !ResizeLocation.IsEmpty) {
                    if (panResize.Cursor == Cursors.SizeNWSE)
                        Size = new Size(e.Location.X - ResizeLocation.X, e.Location.Y - ResizeLocation.Y);
                    else if (panResize.Cursor == Cursors.SizeWE)
                        Size = new Size(e.Location.X - ResizeLocation.X, Size.Height);
                    else if (panResize.Cursor == Cursors.SizeNS)
                        Size = new Size(Size.Width, e.Location.Y - ResizeLocation.Y);
                }
                else if (e.X - panResize.Width > -16 && e.Y - panResize.Height > -16)
                    panResize.Cursor = Cursors.SizeNWSE;
                else if (e.X - panResize.Width > -16)
                    panResize.Cursor = Cursors.SizeWE;
                else if (e.Y - panResize.Height > -16)
                    panResize.Cursor = Cursors.SizeNS;
                else {
                    panResize.Cursor = Cursors.Default;
                }
    
            }
    
            void panResize_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                ResizeLocation = Point.Empty;
            }
