            public partial class Form1 : Form
            {
                Form2 frm2;
                public Form1()
                {
                    InitializeComponent();
                    frm2 = new Form2();
                }
                private void btnOpenFile_Click(object sender, EventArgs e)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        frm2.FileName = openFileDialog1.FileName;
                        frm2.Show();
                    }
                }
            }
    
        public partial class Form2 : Form
        {
            string _fileName = "";
             public string FileName
            {
                get
                {
                    return this._fileName;
                }
                set
                {
                    this._fileName = value;
                }
            }
        }
