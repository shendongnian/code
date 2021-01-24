    public class MyTLP : TableLayoutPanel
    {
        public MyTLP()
        {
            Padding = new Padding(0, 30, 0, 0);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Orange,
                new Rectangle(0, 0, ClientRectangle.Width, Padding.Top));
        }
    }
