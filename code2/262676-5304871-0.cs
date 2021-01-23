    [StructLayout(LayoutKind.Explicit)]
    struct uAWord {
        [FieldOffset(0)] 
        private uint theWord = 0;
        [FieldOffset(0)] 
        public int m_P;
        [FieldOffset(1)] 
        public int m_S;
        [FieldOffset(3)] 
        public int m_SS;
        [FieldOffset(7)] 
        public int m_O;
        [FieldOffset(18)] 
        public int m_D;
        public uAWord(uint theWord){
            this.theWord = theWord;
        }
    }
