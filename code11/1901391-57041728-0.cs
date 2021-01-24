    using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
    {
        fileStream.Seek(0, SeekOrigin.End);
        using (var streamWriter = new StreamWriter(fileStream))
        {
            streamWriter.Write(text);
            Console.ReadLine();
        }
    }
