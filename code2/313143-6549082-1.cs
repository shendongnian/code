    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = this.BackColor = Color.Fuchsia;
            this.StartPosition = FormStartPosition.Manual;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            this.Location = new Point((this.Owner.Width - this.Width) / 2, (this.Owner.Height - this.Height) / 2);
        }
        private void button1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
