    // You might have to change the location of the directory
    var files = Directory.GetFiles(@"Pictures\");
    foreach(var file in files)
    {
        if(file.Contains(id.ToString()))
        {
             return System.IO.File.ReadAllBytes("Pictures\\"+file);
        }
    }
    
