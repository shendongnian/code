    public partial class LinkLabelTextBoxPlayerName : UserControl
    {
        public LinkLabelTextBoxPlayerName()
        {
            InitializeComponent();
            this.textBox.Hide();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel.Hide();
            this.textBox.Show();
            this.textBox.Focus();
            this.textBox.KeyPress += new KeyPressEventHandler(textBoxPlayerName_KeyPress);
            this.textBox.LostFocus += new EventHandler(textBoxPlayerName_LostFocus);
        }
        private void textBoxPlayerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && String.IsNullOrEmpty(this.textBox.Text.Trim()))
            {
                this.textBox.Hide();
                this.linkLabel.Text = "<click to add player>"; //orignal text;
                this.linkLabel.Show();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                this.textBox.Hide();
                this.linkLabel.Text = this.textBox.Text;
                this.linkLabel.Show();
            }
        }
        private void textBoxPlayerName_LostFocus(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(this.textBox.Text.Trim())))
            {
                this.textBox.Hide();
                this.linkLabel.Text = this.textBox.Text;
                this.linkLabel.Show();
            }
            else
            {
                this.textBox.Hide();
                this.linkLabel.Text = "<click to add player>"; //orginal text;
                this.linkLabel.Show();
            }
        }
    }
