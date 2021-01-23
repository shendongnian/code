    class MyControl : UserControl
    {
        public MyControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        protected override void  OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Red);
        }
        void RandomEventThatRequiresRefresh(object sender, EventArgs e)
        {
            Refresh();
        }
    }
