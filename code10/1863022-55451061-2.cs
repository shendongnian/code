    private class SwappedOuterList<T> : IList<T> // TODO: IReadOnlyList<T> etc?
    {
        public IList<IList<T>> Source {get; set; }
        public int OuterIndex{get; set;}
        public T this[int index]
        {
            get {return this.Source.GetSwapped(this.OuterIndex, index); 
            set this.Source.SetSwapped(this.OuterIndex, index) = value;
        }
