    public class PictureBoxEx : PictureBox
    {
        public PictureBoxEx()
        {
            this.SetStyle(ControlStyles.Selectable, true);
        }
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            base.OnClick(e);
        }
    }
