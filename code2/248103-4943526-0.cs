    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Handled)
            {
                mUserCtrl.OnKeyDown(/* convert e into a Controls.KeyEventArgs and pass it */);
            }
        }
    }
