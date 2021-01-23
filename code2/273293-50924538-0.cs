     protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if(m.Msg == (int) WindowsMessages.Win32Messages.WM_PAINT)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    //Double buffering stuff...
                    BufferedGraphicsContext currentContext;
                    BufferedGraphics myBuffer;
                    currentContext = BufferedGraphicsManager.Current;
                    myBuffer = currentContext.Allocate(g,
                       this.ClientRectangle);
                    Rectangle r = ClientRectangle;
                    //Painting background
                    if(Enabled)
                        myBuffer.Graphics.FillRectangle(new SolidBrush(_backColor), r);
                    else
                        myBuffer.Graphics.FillRectangle(Brushes.LightGray, r);
                    //Painting border
                    r.Height = this.DisplayRectangle.Height +1; //Using display rectangle hight because it excludes the tab headers already
                    r.Y = this.DisplayRectangle.Y - 1; //Same for Y coordinate
                    r.Width -= 5;
                    r.X += 1;
                    if(Enabled)
                        myBuffer.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 133, 158, 191), 1), r);
                    else
                        myBuffer.Graphics.DrawRectangle(Pens.DarkGray, r);
                    myBuffer.Render();
                    myBuffer.Dispose();
                    //Actual painting of items after Background was painted
                    foreach (int index in ItemArgs.Keys)
                    {
                        CustomDrawItem(ItemArgs[index]);
                    }
                }
            }    
        }
