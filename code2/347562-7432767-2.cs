    struct TenChars1
    {
        public const int Capacity = 10;
        private char A;
        private char B;
        private char C;
        private char D;
        private char E;
        private char F;
        private char G;
        private char H;
        private char I;
        private char J;
        public TenChars1(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length > Capacity) throw new ArgumentException();
            A = (value.Length > 0) ? value[0] : '\0';
            B = (value.Length > 1) ? value[1] : '\0';
            C = (value.Length > 2) ? value[2] : '\0';
            D = (value.Length > 3) ? value[3] : '\0';
            E = (value.Length > 4) ? value[4] : '\0';
            F = (value.Length > 5) ? value[5] : '\0';
            G = (value.Length > 6) ? value[6] : '\0';
            H = (value.Length > 7) ? value[7] : '\0';
            I = (value.Length > 8) ? value[8] : '\0';
            J = (value.Length > 9) ? value[9] : '\0';
        }
        public override string ToString()
        {
            return new string(new char[] { A, B, C, D, E, F, G, H, I, J });
        }
    }
    unsafe struct TenChars2
    {
        public const int Capacity = 10;
        private fixed char buffer[Capacity];
        public TenChars2(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length > Capacity) throw new ArgumentException();
            fixed (char* ptr = this.buffer)
            fixed (char* chars = value)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    *(ptr + i) = *(chars + i);
                }
            }
        }
        public override string ToString()
        {
            fixed (char* ptr = this.buffer)
            {
                return new string(ptr);
            }
        }
    }
