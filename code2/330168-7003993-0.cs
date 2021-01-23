        Pen bp = new Pen(Color.Black, 3f);
        for (float i = scale; i <= this.ClientSize.Width - scale; i += scale)
        {
            int iAsInt = (int)i;
            int scaleAsInt = (int)scale;
            int w = ClientSize.Width;
            counter++;
            if ((counter - 1) % 3 != 0)
            {
                g.DrawLine(Pens.Black, new Point(iAsInt, scaleAsInt), new Point(iAsInt, w - scaleAsInt);
                g.DrawLine(Pens.Black, new Point( scaleAsInt, iAsInt), new Point(w - scaleAsInt, iAsInt));
            }
            else
            {
                
                g.DrawLine(bp, new Point(iAsInt, scaleAsInt), new Point(iAsInt, w - scaleAsInt);
                g.DrawLine(bp, new Point(scaleAsInt, iAsInt), new Point(w - scaleAsInt, iAsInt));
            }
        }
