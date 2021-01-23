    struct Integer
    {
        public int Value;
        // just for kicks
        public static implicit operator Integer(int value)
        {
            return new Integer { Value = value };
        }
    }
