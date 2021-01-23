    public void PopulateSourceDirectory(IEnumerable<ImageDirectory> dirs)
    {
        foreach (var directory in dirs)
        {
            ListViewItem item = new ListViewItem();
            item.Group = lstViewSource.Groups[0];
            item.Text = Path.GetFileName(directory.Directory);
            item.ImageKey = directory.Image;
            item.Tag = directory;
            lstViewSource.Items.AddRange(new ListViewItem[] { item });
        }
    }
