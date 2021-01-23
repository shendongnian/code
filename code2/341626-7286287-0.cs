    var strings = Controls.OfType<TextBox>()
                          .Select(x => x.Text)
                          .Where(text => !string.IsNullOrEmpty(text))
                          .ToList();
    using (ZipFile ZipIt = new ZipFile())
    {
        nxtFileNum++;
        string comment = string.Format("This archive was created at {0:G}",
                                       DateTime.Now);
        foreach (string directory in strings)
        {
            ZipIt.AddDirectory(directory);
            ZipIt.Comment = comment;
            ZipIt.Save(Destination);
        }
    }   
