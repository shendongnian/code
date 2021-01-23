        class WinForm : Form
        {
            bool FrameLoop = false;
            int FrameIndex = 0;
            int FrameCount = 0;
            FrameDimension FrameDimension = null;
            List<int> DelayTime = new List<int>();
            Image img;
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                this.DoubleBuffered = true;
                img = Image.FromFile("C:\\debug.gif");
                if (img.FrameDimensionsList != null)
                    foreach (Guid i in img.FrameDimensionsList)
                    {
                        FrameDimension = new FrameDimension(i);
                        FrameCount = img.GetFrameCount(FrameDimension);
                    }
                if (FrameCount > 1)
                {
                    foreach (PropertyItem i in img.PropertyItems)
                    {
                        if (i.Id == 0x5100)
                        {
                            for (int j = 0; j < FrameCount; j++)
                            {
                                DelayTime.Add(BitConverter.ToInt32(i.Value, j * 4));
                            }
                        }
                        else if (i.Id == 0x5101)
                        {
                            FrameLoop = true;
                        }
                    }
                    this.BeginInvoke(new EventHandler(Animation));
                }
            }
            private void Animation(object sender,EventArgs e)
            {
                img.SelectActiveFrame(FrameDimension, FrameIndex);
                this.Refresh();
                Application.DoEvents();
                Thread.Sleep(DelayTime[FrameIndex] * 10);
                FrameIndex++;
                if (FrameIndex >= FrameCount)
                {
                    if (FrameLoop)
                        FrameIndex = 0;
                    else
                        return;
                }
                Animation(sender, e);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                if (img == null)
                    return;
                e.Graphics.DrawImage(img, new Point(0, 0));
                //base.OnPaint(e);
            }
        }
