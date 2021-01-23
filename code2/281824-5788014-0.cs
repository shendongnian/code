    private abstract class A
    {
        protected int Number { get; private set; }
    }
    private class B : A
    {
        public int GetNumber()
        {
            return Number;
        }
    }
