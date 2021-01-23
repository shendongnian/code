    if (System.Console.OpenStandardOutput()
        .BeginWrite(new byte[] { 101, 108, 108, 111, 032, 087, 111, 114, 108, 100, 033 },
                    0, 12, null, null)
        .AsyncWaitHandle.WaitOne())
    {}
