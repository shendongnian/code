    public IList<T> this [int index]
    {
        get
        {
            return new SwappedOuterList<T>
            {
                Source = this.Source,
                OuterIndex = index,
            };
        }
