    class LossyStack<T> : Stack<T>
    {
        private int getAway = 1;  // Starts out at 1 (out of 20 random numbers - 5%)
        public Stack<T> escaped = new Stack<T>();
        public LossyStack()
            : base()
        {   // Constructor
        }
        public T Pop()
        {
            Random rand = new Random();
            if (rand.Next(20) <= getAway)
            {
                escaped.Push(base.Pop());
            }
            else
            {
                return base.Pop();
            }
            getAway++; // add another 1 to getAway so it increases by 5%
        }
    }
