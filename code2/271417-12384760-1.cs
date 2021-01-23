           base.OnPaintBackground(e);
           Graphics g = e.Graphics;
           if (Parent != null)
           {
               // Take each control in turn
               int index = Parent.Controls.GetChildIndex(this);
               for (int i = Parent.Controls.Count - 1; i > index; i--)
               {
                   Control c = Parent.Controls[i];
                   // Check it's visible and overlaps this control
                   if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                   {
                       // Load appearance of underlying control and redraw it on this background
                       Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                       c.DrawToBitmap(bmp, c.ClientRectangle);
                       g.TranslateTransform(c.Left - Left, c.Top - Top);
                       g.DrawImageUnscaled(bmp, Point.Empty);
                       g.TranslateTransform(Left - c.Left, Top - c.Top);
                       bmp.Dispose();
                   }
               }
           }
       }
