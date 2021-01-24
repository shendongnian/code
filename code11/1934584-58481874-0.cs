    var progress = new Form();
    this.BeginInvoke(new Action(() =>
    {
        for (int i = 0; i < 100; i++)
        {
            System.Threading.Thread.Sleep(16); // do a bit of my process
            // Update progress dialog
            Application.DoEvents();
        }
        progress.Close();
    }));
    progress.ShowDialog();
