    public string FolderPath { get; private set; }
    private void SelectPath() {
        using(var dlg = new FolderBrowserDialog()) { // or whatever type
            if(dlg.ShowDialog() == DialogResult.OK) {
                FolderPath = dlg.SelectedPath;
            }
        }
    }
    
