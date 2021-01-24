    public partial class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
            FormC.InstanceClosed += (sender, e) =>
            {
                MessageBox.Show(((Form)sender).Name + " Closed, reason: " + e.CloseReason);
            };
        }
    }
