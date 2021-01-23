    var file = File.AppendText(@"c:\output.txt");
    
    foreach (string tmpLine in File.ReadAllLines(@"c:\filename.txt"))
    {
        if (File.Exists(tmpLine))
        {       
            file.WriteLine(tmpLine);
        }
    }
    
    file.Close();
