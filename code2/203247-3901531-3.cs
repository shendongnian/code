    using (FileStream fs = new FileStream(fileToReadPath, FileMode.Open))
    using (StreamReader reader = new StreamReader(fs))
    {
        string text = reader.ReadToEnd();
        Console.WriteLine(text);
        fs.Seek(0, SeekOrigin.Begin); // ObjectDisposedException not thrown now
        text = reader.ReadToEnd();
        Console.WriteLine(text);
    }
