    public partial class MyUserControl : UserControl
    {
        public delegate void ControlRemoveEventHandler(object sender, EventArgs e);
        public event ControlRemoveEventHandler ControlRemoveNotify;
        public MyUserControl() => InitializeComponent();
        private void btnRemoveControl_Click(object sender, EventArgs e)
            => ControlRemoveNotify?.Invoke(this, e);
    }
