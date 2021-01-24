    public static class Module
    {   
        private const string SourceA = "A";
        private const string SourceB = "B";
        public static WriteA(string text)
        {
            Write(SourceA, text);
        } 
        public static WriteB(string text)
        {
            Write(SourceB, text);
        } 
        private static Write(string source, string text)
        {
            OtherStaticClass.Log(source, text);
        }
    }
