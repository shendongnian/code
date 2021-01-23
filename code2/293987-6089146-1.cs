    public Form1(string path) {
                InitializeComponent();
    
                if (path != string.Empty && Path.GetExtension(path).ToLower() != ".bgl") {
                    MessageBox.Show("Dropped File is not Bgl File","File Type Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    path = string.Empty;
                }
    .......
    }
