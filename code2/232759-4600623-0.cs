    public struct Vector<TElement, TImpl> where TImpl : struct, IImplementation<TElement>
    {
        private TImpl impl;
        
        public int Dimensions { get { return impl.Dimensions; } }
        public TElement this[int index]
        {
            get { return impl[index]; }
            set { impl[index] = value; }
        }
    }
