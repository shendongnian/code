    class MyClass
    {
        bool flags[] = new flags[10];
        public bool IsBool1 { get { return flags[0]; } set { flags[0] = value; } }
        public bool IsBool2 { get { return flags[1]; } set { flags[1] = value; } }
        ...
        public bool IsBool10 { get { return flags[9]; } set { flags[9] = value; } }
        public void SetFlagsByCounter(int counter)
        {
            for (int i = 0; i < counter; i++)
            {
                flags[i] = true;
            }
        }
    }
