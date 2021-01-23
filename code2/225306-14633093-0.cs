    class SkippableStreamReader : StreamReader
    {
        public SkippableStreamReader(string path) : base(path) { }
        public void SkipLines(int linecount)
        {
            for (int i = 0; i < linecount; i++)
            {
                this.ReadLine();
            }
        }
    }
