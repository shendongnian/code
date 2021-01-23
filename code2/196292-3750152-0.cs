        struct Ratio
    {
        public void VoteA()
        {
            A++;
        }
        public void VoteB()
        {
            B++;
        }
        public int A { get; private set; }
        public int B { get; private set; }
        public override string ToString()
        {
            return A + ":" + B;
        }
    }
