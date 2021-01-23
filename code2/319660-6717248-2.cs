    using (Stream stream = typeof(System.Timers.Timer).Assembly.
                               GetManifestResourceStream("System.Timers.Timer.bmp"))
    {
        using (Bitmap bitmap = new Bitmap(stream))
        {
            //bitmap.Dump();
        }
    }
