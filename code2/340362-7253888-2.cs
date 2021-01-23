    using (var s = new FileStream("application.log", FileMode.Append, FileAccess.Write)
    {
        var bytes = new byte[] { 1, 2, 3, 4, 5 };
        s.Write(bytes, 0, bytes.Length);
    }
