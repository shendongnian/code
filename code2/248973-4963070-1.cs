    class MyEffect : IEffect
    {
        IEffect _owner;
        public MyEffect(IEffect owner) 
        {
            _owner = owner;
        }
        public int GetFunkyHash()
        {
            int hash = this.GetHashCode();
            int index = _owner.IndexOf(item);
            return hash | index.GetHashCode();
        }
    }
