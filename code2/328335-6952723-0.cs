    public struct FixedLengthString
    {
        private readonly string s;
        public FixedLengthString(char c1, char c2, char c3)
        {
            this.s = new string(new [] { c1, c2, c3 });
        }
    }
