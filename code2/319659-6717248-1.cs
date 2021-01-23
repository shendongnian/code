    using (Stream stream = typeof(Uri).Assembly.
                               GetManifestResourceStream("System.Timers.Timer.bmp"))
    {
        using (Bitmap bitmap = new Bitmap(stream))
        {
            //bitmap.Dump();
        }
    }
