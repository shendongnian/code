    public partial class MyUserControl : UserControl
    {
        public MyUserControl() => InitializeComponent();
        private void btnRemoveControl_Click(object sender, EventArgs e)
            => this.Dispose();
    }
