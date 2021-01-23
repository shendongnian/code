    // Wrong
    class Bad
    {
        void Method1()
        {
            List<string> str = new List<string>();
        }
        void Method2()
        {
            foreach (string item in str)
            {
                ...
            }
        }
    }
    // Right
    class Good
    {
        private List<string> str = new List<string>();
        void Method1()
        {
            str = CreateSomeOtherList();
        }
        void Method2()
        {
            foreach (string item in str)
            {
                ...
            }
        }
    }
