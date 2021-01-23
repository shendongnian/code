           public Bitmap printGraphPane()
           {
            ZedGraphControl graph = new ZedGraphControl();
            GraphPane newGP = myPane.GraphPane;
            //newGP.YAxis.Scale.Mag = 0;
            //newGP.YAxis.Scale.Format = "#";
            //newGP.YAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(YAxis_ScaleFormatEvent);
            Bitmap bit = new Bitmap(newGraph.Width, newGraph.Height);
            newGraph.ClientSize = bit.Size;
            newGraph.DrawToBitmap(bit, new Rectangle(0, 0, newGraph.Width, newGraph.Height));
            return bit;
           }
