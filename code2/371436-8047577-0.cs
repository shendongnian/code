    public class ClearPanel : Panel
    {
        public ClearPanel(){}
    
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020;
                return createParams;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e){}
    }
