    public class TransparentPanel : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TRANSPARENT = 0x00000020;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TRANSPARENT
                return cp;
            }
        }
 
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Do nothing
        }
    }
