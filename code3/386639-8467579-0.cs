    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                RegisterControls(this.Controls);
            }
        }
        public event EventHandler ChildControlGotFocus;
        private void RegisterControls(ControlCollection cControls)
        {
            foreach (Control oControl in cControls)
            {
                oControl.GotFocus += new EventHandler(oControl_GotFocus);
                if (oControl.HasChildren)
                {
                    RegisterControls(oControl.Controls);
                }
            }
        }
        void oControl_GotFocus(object sender, EventArgs e)
        {
            if (ChildControlGotFocus != null)
            {
                ChildControlGotFocus(this, new EventArgs());
            }
        }
    }
