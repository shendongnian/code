    string path = "C:\\test.txt";
    FileInfo info = new FileInfo(path);
    info.IsReadOnly = false;
    StreamWriter writer = new StreamWriter(path);
    writer.WriteLine("This is an example.");
    writer.Close();
    info.IsReadOnly=true;
