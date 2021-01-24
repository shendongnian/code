    using System.Linq;
    private void btnLogin_Click(object sender, EventArgs e)
    {
        WebClient wc = new WebClient();
        var fileContents = wc.DownloadString("http://LinkToTextFile.txt");
        //Todo 1: Error handling, check for empty!
        //Todo 2: Handle case in-sensitive comparison!
        string[] lines = fileContents.Split(null);
        
        if (string.IsNullOrEmpty(txtBxAccessKey.Text))
        {
            MessageBox.Show("Empty");
            return;
        }
        else if (lines.Contains(txtBxAccessKey.Text))
        {
            this.Hide();
            Loader frmLoader = new Loader();
            frmLoader.ShowDialog();
        }
        else
        {
            MessageBox.Show("Access Key Not Found");
        }
    }
