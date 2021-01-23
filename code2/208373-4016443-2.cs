    class Act
    {
        [Obsolete("DoSomething(int, int) is obsolete", false /*warn only*/)]
        public void DoSomething(int i, int j)
        {
        }
        public void DoSomething(int i)
        {
        }
    }
