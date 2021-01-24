    public static class MusicHandler
    {
        public static MusicCapture.MusicCapture MusicCapture;
        public static bool Initialized {get;} = False;
        public static void init()
        {
            MusicCapture = new MusicCapture.MusicCapture("D:\\Temp", "D:\\test", "E:\\FingerPrintDB2.ss");
            MusicCapture.Start();
            Initialized = true;
        }
    }
