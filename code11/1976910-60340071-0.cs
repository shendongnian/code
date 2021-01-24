    var dir = new DirectoryInfo(folderpath);
    var files = dir.GetFiles();
    foreach (FileInfo f in files)
    {
        var oldname = Path.GetFileNameWithoutExtension(f.Name);
        var newname = oldname.Substring(0, oldname.Length / 2);
        File.Move(f.FullName, f.FullName.Replace(oldname, newname));
    }
