    public class ChartEx : Chart
    {
        public event EventHandler CustomEvent;
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
            }
            catch (InvalidOperationException ex)
            {
                if (CustomEvent != null)
                {
                    CustomEvent(this, e);
                }
            }
        }
    }
