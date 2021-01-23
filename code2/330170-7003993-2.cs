        Graphics g = e.Graphics;
        Pen bp = new Pen(Color.Black, 3f);
        Point start = new Point(0,0);
        Point stop = new Point(0,0);
        for (float i = scale; i <= this.ClientSize.Width - scale; i += scale)
        {
            int iAsInt = (int)i;
            int scaleAsInt = (int)scale;
            int w = ClientSize.Width;
            counter++;
            if ((counter - 1) % 3 != 0)
            {
                start.X = iAsInt;
                start.Y = scaleAsInt;
                stop.X = iAsInt;
                stop.Y = w-scaleAsInt;
                g.DrawLine(Pens.Black, start, stop);
                start.X = scaleAsInt;
                start.Y = iAsInt;
                stop.X = w-scaleAsInt;
                stop.Y = iAsInt;
                g.DrawLine(Pens.Black, start, stop);
                // Note: this looks like more work, but it is actually less
                // your code still has to make all the assignments in addition to 
                // newing up the points (and later having to garbage collect them)
            }
            else
            {
                // TODO: reuse the start/stop points here
                g.DrawLine(bp, new Point(iAsInt, scaleAsInt), new Point(iAsInt, w - scaleAsInt);
                g.DrawLine(bp, new Point(scaleAsInt, iAsInt), new Point(w - scaleAsInt, iAsInt));
            }
        }
