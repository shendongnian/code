        public Form1()
        {
            InitializeComponent();
        }
        bool fileSelected = false; //default false because nothing selected at start.
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    private void button1_Click(object sender, EventArgs e)
        {
            openFile();
            if (fileSelected == true)
            {
                codes...
            }
        }
        string path= "";
        private void openFile()
        {
            OpenFileDialog file= new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Filter = "Text File|*.txt";
            //file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                path= dosya.FileName;
                fileSelected = true;
            }
            else
            {
                MessageBox.Show("File not selected.");
            }
        }
