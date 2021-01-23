    var items = System.IO.Directory.GetFiles("Directory A", "*.bak", System.IO.SearchOption.TopDirectoryOnly);
    foreach(String filePath in items)
    {
        var newFile = System.IO.Path.Combine("Directory B", System.IO.Path.GetFileName(filePath));
        System.IO.File.Copy(filePath, newFile);
    }
