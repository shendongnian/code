    public class EndPointPictureBox : PictureBox
    {
        private List<PointF> points = new List<PointF>();
        public EndPointPictureBox()
        {
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            points.Add(new PointF(e.X,e.Y));
            base.OnMouseDown(e);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            foreach(var point in points)
                g.DrawRectangle(Pens.Black,point.X-2.0f,point.Y-2.0f,4.0f,4.0f);
            if(points.Count>1)
                g.DrawLines(Pens.Black,points.ToArray());
            
        }
    }
