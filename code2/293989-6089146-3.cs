    public Form1(string path) {
                InitializeComponent();
    
                if (path != string.Empty && Path.GetExtension(path).ToLower() != ".bgl") {
                    //Do whatever
                }
