    namespace CC_Case_Maker
    {
        public partial class add_thing : Form
        {
            public string piccpath1 { get; set; }
            public string piccpath2 { get; set; }
            public string description { get; set; }
            public string titlee { get; set; }
    
            public add_thing()
            {
                InitializeComponent();
               
                
            }
    
            private void label1_Click(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string picpath = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(picpath);
                    string[] extract = Regex.Split(picpath, "evidence");
                    string pipath2 = Regex.Replace(extract[1], "evidence", "");
                    piccpath1 = picpath;
                    piccpath2 = pipath2;
    
                }
                
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                description = richTextBox1.Text;
                titlee = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
