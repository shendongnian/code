    public class FormPanel : Panel
    {
        public FormPanel()
        {
            this.Dock = DockStyle.Fill;
        }
        [System.ComponentModel.DefaultValue(typeof(DockStyle), "Fill")]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }
    }
