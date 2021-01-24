    public partial class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
            GlobalStaticClass.FormClosed += (sender, e) =>
            {
                //if (sender is FormC)
                MessageBox.Show(((Form)sender).Name + " Closed, reason: " + e.CloseReason);
            };
        }
    }
