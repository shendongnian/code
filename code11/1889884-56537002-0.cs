    string csv = "csv path";
    string sourcedir = @"C:\temp1\";
    string targetdir = @"C:\temp2\";
    
    var items = File.ReadAllLines(csv);
    
    foreach(var item in items)
    {
        var paths = item.Split(";");
        string sourcePath = Path.Combine(sourcedir, paths[0]);
        string targetPath = Path.Combine(targetdir, paths[1]);
    
        System.IO.Directory.CreateDirectory(targetPath);
    
        string[] files = System.IO.Directory.GetFiles(sourcePath);
    
        foreach (string s in files)
        {
            var fileName = System.IO.Path.GetFileName(s);
            var destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(s, destFile, true);
        }
    }
