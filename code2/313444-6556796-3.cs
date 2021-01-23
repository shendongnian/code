    private void LoadClick(object sender, EventArgs e)
    {
        using (var stream = File.Open(filename, FileMode.Open))
        {
            var formatter = new SoapFormatter();
                
            this.ctrl11.CopyFrom((UserControl1)formatter.Deserialize(stream));
        }
    }
