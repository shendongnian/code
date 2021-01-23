        protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen myPen = new Pen(System.Drawing.Color.Black, 5.0))
            {
               foreach(ConnectionLine cl in connectionLines)
                       e.Graphics.DrawLine(myPen, cl.xStart, cl.yStart, cl.xStop, cl.yStop);
            }
        }
