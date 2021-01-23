    class BaseTypeList<TBase, TDerived> : IList<TBase>
        where TBase : class
        where TDerived : class, TBase 
    {
        private readonly IList<TDerived> m_derivedList;
        public BaseTypeList(IList<TDerived> derivedList)
        {
            m_derivedList = derivedList;
        }
        public IEnumerator<TBase> GetEnumerator()
        {
            return m_derivedList.Cast<TBase>().GetEnumerator();
        }
        public void Add(TBase item)
        {
            var derivedItem = item as TDerived;
            if (derivedItem == null)
                throw new ArgumentException();
            m_derivedList.Add(derivedItem);
        }
        public void Clear()
        {
            m_derivedList.Clear();
        }
        // other members implemented in a similar fashion
    }
