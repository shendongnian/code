    using (var stream = typeof(Uri).Assembly.
                            GetManifestResourceStream("System.Timers.Timer.bmp"))
    {
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, (int)stream.Length);
        // ...
    }
