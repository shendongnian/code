        public class RotatePanel : Panel, IRotate
        {
    
            public RotatePanel() : base()
            {
                Angle = 0;
            }
    
    
            protected override void OnPaint(PaintEventArgs e)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    foreach (IRotate control in this.Controls)
                    {
                        control.Angle = Angle;
                    }
                    g.RotateTransform(Angle);
                    g.DrawRectangle(new System.Drawing.Pen(new SolidBrush(Color.Black), 2f), 4f, 4f, 10f, 10f);
                    g.DrawRectangle(new System.Drawing.Pen(new SolidBrush(Color.Azure), 2f), 14f, 14f, 30f, 30f);
                    g.Flush();
                }
                base.OnPaint(e);
            }
    
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                base.OnPaintBackground(e);
            }
    
            public float Angle
            {
                get;
                set;
            }
        }
    
        public interface IRotate
        {
            float Angle { get; set; }
        }
    
       public class RotateCheckBox : CheckBox, IRotate
        {
            public float Angle { get; set; }
            public RotateCheckBox():base()
            {
                Angle = 0;
            }
    
    
            protected override void OnPaint(PaintEventArgs pevent)
            {
                pevent.Graphics.RotateTransform(this.Angle);
                pevent.Graphics.Flush();
                base.OnPaint(pevent);
            }
        }
