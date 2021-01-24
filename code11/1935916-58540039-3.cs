        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory(FileSystemWatcher1.Path);
            FileSystemWatcher1.EnableRaisingEvents = true;
            File.WriteAllText(alphaBeta + @"\Gamma.dat", "Delta");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            FileSystemWatcher1.EnableRaisingEvents = false;
            Directory.Delete("Alpha", true);//Recursively Delete
        }
