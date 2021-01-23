    string closeTag = "</root>";
    int closeLength = Encoding.UTF8.GetBytes(closeTag).Length;
    
    var fs = System.IO.File.Open(filename, System.IO.FileMode.Open);
    fs.Position = fs.Length - closeLength;
    
    var writer = new StreamWriter(fs);
    
    writer.WriteLine(newTag);
    writer.Write(closeTag);  // NOT WriteLine !!
    
    writer.Close();
    fs.Close();
