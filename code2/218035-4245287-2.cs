    DirectoryInfo Folder = new DirectoryInfo(textboxPath.Text);
    var dir = @"D:\New folder\log";
    if (Folder.Exists)
    {                
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
    }
    if (File.Exists(FilePath))
    {
        // Read the file and display it line by line.
        using (var file = File.OpenText(FilePath))
        using (var dest = File.AppendText(Path.Combine(dir, "log.txt")))
        {
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(regMatch))
                {
                    dest.WriteLine("LineNo : " + counter.ToString() + " : " +
                         line + "<br />");
                }
                counter++;
            }
        }
    }
