    public partial class MyUserControl: UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form(); //Your custom dialog form
            this.Disposed += (obj, args) => { f.Close(); f.Dispose(); };
            f.ShowDialog();
        }
    }
