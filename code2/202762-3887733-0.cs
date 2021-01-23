    public struct Swapable
    {
        public int A;
        public int B;
    }
    public Swapable Swap(Swapable swapable)
    {
        return new Swapable()
        {
            A = swapable.B;
            B = swapable.A;
        };
    }
