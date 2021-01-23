    string comment = string.Format("This archive was created at {0:G}",
                                   DateTime.Now);
    int fileIndex = 0;
    foreach (string directory in strings)
    {
        fileIndex++;
        using (ZipFile zipFile = new ZipFile())
        {
            zipFile.AddDirectory(directory);
            zipFile.Comment = comment;
            zipFile.Save(Destination + "." + fileIndex);
        }
    }
