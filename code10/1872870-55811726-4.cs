    class X
    {
        public int[] MyArray
        {
             get;
             set;
        }
        public int ArrayLength
        {
            set
            {
                 MyArray = new int[value];
            }
        }
    }
