               // To zoom in controls.
                foreach (Control c in MyFlowLayoutPanel.Controls)
                {
                    PictureBox ptc = c as PictureBox;
                    if (null != ptc)
                    {
                        Point pt = new Point(2, 2);
                        SizeF sf = new SizeF(pt);
                        c.Scale(sf);
                    }
                }
