    public partial class add_thing : Form
    {
        public string piccpath1 { get; set; }
        public string piccpath2 { get; set; }
        public string description { get; set; }
        public string titlee { get; set; }
        public add_thing() => InitializeComponent();
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                string picPath = openFileDialog1.FileName;
                pictureBox1.Image = (Bitmap)Image.FromFile(picpath).Clone();
                string[] extract = Regex.Split(picpath, "evidence");
                string piPath2 = Regex.Replace(extract[1], "evidence", "");
                this.piccpath1 = picPath;
                this.piccpath2 = piPath2; 
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.description = richTextBox1.Text;
            this.titlee = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
