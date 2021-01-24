    class Printable
    {
        protected readonly Action _action;
        public Printable(Action printAction)
        {
            _action = printAction;
        }
        public void Print()
        {
            _action();
        }
    }
