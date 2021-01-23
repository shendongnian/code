                Rectangle rect = new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 6, e.Bounds.Height);
                backColorBrush = new SolidBrush(Color.CornflowerBlue);
                e.Graphics.FillRectangle(backColorBrush, rect);
                string tabName = this.TabPages[e.Index].Text;
                TabPages[e.Index].BackColor = Color.AliceBlue;
                TabPages[e.Index].BorderStyle = BorderStyle.None;
                TabPages[e.Index].UseVisualStyleBackColor = false;
                TabPages[e.Index].RightToLeft = RightToLeft.No;
                myFormat.Alignment = StringAlignment.Near;
                myFont = new Font(e.Font, FontStyle.Bold);
                RectangleF r1 = new RectangleF(e.Bounds.X + 1, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height - 4);
                foreColorBrush = new System.Drawing.SolidBrush(Color.Black);
                e.Graphics.DrawString(tabName, myFont, foreColorBrush, r1, myFormat);
                // e.Graphics.DrawImage(img, new Point(rect.X + (GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
            }
            else
            {
                myFont = new Font(e.Font, FontStyle.Bold);
                backColorBrush = new System.Drawing.SolidBrush(Color.CadetBlue);
                foreColorBrush = new System.Drawing.SolidBrush(Color.Black);
                TabPages[e.Index].BackColor = Color.AliceBlue;
                string tabName = TabPages[e.Index].Text;
                Rectangle rect = new Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height + 1);
                myFormat.Alignment = StringAlignment.Near;
                e.Graphics.FillRectangle(backColorBrush, rect);
                RectangleF r1 = new RectangleF(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height - 4);
                e.Graphics.DrawString(tabName, myFont, foreColorBrush, r1, myFormat);
                //e.Graphics.DrawImage(img, new Point(rect.X + (GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
            }
            myFormat.Dispose();
            myFont.Dispose();
            backColorBrush.Dispose();
            foreColorBrush.Dispose();
