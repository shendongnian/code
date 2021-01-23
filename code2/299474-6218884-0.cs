        internal class APNGBox
        {
            public int frameNum { get; set; }
            public APNGLib.APNG apng { get; set; }
            public Bitmap buffer { get; set; }
            public Bitmap prevBuffer { get; set; }
            public APNGBox(APNGLib.APNG png)
            {
                frameNum = 0;
                apng = png;
                buffer = apng.ToBitmap(0);
                prevBuffer = null;
            }
        }
        private void UpdateUI()
        {
            foreach (PictureBox pb in pics)
            {
                APNGBox box = (APNGBox)pb.Tag;
                APNGLib.APNG png = box.apng;
                if (!png.IsAnimated)
                {
                    if (pb.Image == null)
                    {
                        pb.Image = png.ToBitmap();
                    }
                }
                else
                {
                    if (box.frameNum != png.FrameCount - 1)
                    {
                        Bitmap prev = box.prevBuffer == null ? null : new Bitmap(box.prevBuffer);
                        APNGLib.Frame f1 = png.GetFrame(box.frameNum);
                        if (f1.DisposeOp != APNGLib.Frame.DisposeOperation.PREVIOUS)
                        {
                            box.prevBuffer = new Bitmap(box.buffer);
                        }
                        DisposeBuffer(box.buffer, new Rectangle((int)f1.XOffset, (int)f1.YOffset, (int)f1.Width, (int)f1.Height), f1.DisposeOp, prev);
                        box.frameNum++;
                        APNGLib.Frame f2 = png.GetFrame(box.frameNum);
                        RenderNextFrame(box.buffer, new Point((int)f2.XOffset, (int)f2.YOffset), png.ToBitmap(box.frameNum), f2.BlendOp);
                    }
                    else
                    {
                        box.frameNum = 0;
                        box.prevBuffer = null;
                        ClearFrame(box.buffer);
                        RenderNextFrame(box.buffer, Point.Empty, png.ToBitmap(box.frameNum), APNGLib.Frame.BlendOperation.SOURCE);
                    }
                    pb.Invalidate();
                }
            }
        }
        private void DisposeBuffer(Bitmap buffer, Rectangle region, APNGLib.Frame.DisposeOperation dispose, Bitmap prevBuffer)
        {
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                Brush b = new SolidBrush(Color.Transparent);
                switch (dispose)
                {
                    case APNGLib.Frame.DisposeOperation.NONE:
                        break;
                    case APNGLib.Frame.DisposeOperation.BACKGROUND:
                        g.FillRectangle(b, region);
                        break;
                    case APNGLib.Frame.DisposeOperation.PREVIOUS:
                        if(prevBuffer != null)
                        {
                            g.FillRectangle(b, region);
                            g.DrawImage(prevBuffer, region, region, GraphicsUnit.Pixel);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void RenderNextFrame(Bitmap buffer, Point point, Bitmap nextFrame, APNGLib.Frame.BlendOperation blend)
        {
            using(Graphics g = Graphics.FromImage(buffer))
            {
                switch(blend)
                {
                    case APNGLib.Frame.BlendOperation.OVER:
                        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                        break;
                    case APNGLib.Frame.BlendOperation.SOURCE:
                        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        break;
                    default:
                        break;
                }
                g.DrawImage(nextFrame, point);
            }
        }
        private void ClearFrame(Bitmap buffer)
        {
            using(Graphics g = Graphics.FromImage(buffer))
            {
                g.Clear(Color.Transparent);
            }
        }
