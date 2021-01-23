    internal class SelectableLabel: Label
    {
        public SelectableLabel():base()
        {
            SetStyle(ControlStyles.Selectable, true);            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle);
            if (!Focused) return;
            if (BorderStyle == BorderStyle.Fixed3D)
            {
                e.Graphics.DrawLines(Pens.CadetBlue, new[] { new Point(1, Height - 1), new Point(1, 1), new Point(Width - 1, 1) });
                e.Graphics.DrawLines(Pens.Aquamarine, new[] { new Point(2, Height - 1), new Point(Width - 1, Height - 1), new Point(Width - 1, 2) });
            }
            else
            {
                e.Graphics.DrawRectangle(Pens.Aquamarine, 0, 0, Width - 1 , Height - 1 );
            }
        }        
    }
