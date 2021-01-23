    public class NumericUpDownWitoutButtons : NumericUpDown
    {
        public NumericUpDownWitoutButtons()
        {
            Controls[0].Visible = false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Window);
            base.OnPaint(e);
        }
    }
