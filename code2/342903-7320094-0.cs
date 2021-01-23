    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
        }
        public void EmbedForm(Form frm) {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Dock = DockStyle.Fill;   // optional
            this.Controls.Add(frm);
        }
    }
