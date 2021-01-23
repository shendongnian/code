    private void populateList( string path )
    {
        string[] files = Directory.GetFiles(path, "*.fbi", SearchOption.AllDirectories);
        foreach (string f in files)
        {
            string entry1 = Path.GetFullPath(f);
            string entry = Path.GetFileName(f);
            listBox1.Items.Add(entry);
        }
    }
