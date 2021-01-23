    struct Struct2
    {
        public int a;
    }
    class wrapper // sorry, cannot use 'struct' here ...
    {
        Struct2 str0;
        Struct2 str1;
        public helper this[int index]
        {
            get
            {
                return new helper (this, index);
            }
        }
        int GetValueA(int index)
        {
            switch (index)
            {
                case 0:  return str0.a;
                case 1:  return str1.a;
                default: throw new System.IndexOutOfRangeException ();
            }
        }
        void SetValueA(int index, int value)
        {
            switch (index)
            {
                case 0: str0.a = value; break;
                case 1: str1.a = value; break;
            }
        }
        public class helper
        {
            public helper(wrapper host, int index)
            {
                this.host  = host;
                this.index = index;
            }
            public int a
            {
                get { return this.host.GetValueA (index); }
                set { this.host.SetValueA (index, value); }
            }
            private readonly wrapper host;
            private readonly int index;
        }
    }
