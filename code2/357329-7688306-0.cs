    protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen myPen = new Pen(System.Drawing.Color.Black))
            {
                myPen.Width = 5;
               foreach(ConnectionLine cl in connectionLines)
                       e.Graphics.DrawLine(myPen, cl.xStart, cl.yStart, cl.xStop, cl.yStop);
           }
        }
