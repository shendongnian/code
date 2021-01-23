        class BitArrayReverse
        {
            private BitArray _ba;
            public BitArrayReverse(BitArray ba) { _ba = ba; }
            public bool this[int index]
            {
                get { return _ba[_ba.Length - 1 - index]; }
                set { _ba[_ba.Length - 1 - index] = value; }
            }
        }
