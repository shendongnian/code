    public class KeysCollection : ICollection, IEnumerable
    {
        // Fields
        private NameObjectCollectionBase _coll;
        // Methods
        internal KeysCollection(NameObjectCollectionBase coll)
        {
            this._coll = coll;
        }
        public virtual string Get(int index)
        {
            return this._coll.BaseGetKey(index);
        }
        public IEnumerator GetEnumerator()
        {
            return new NameObjectCollectionBase.NameObjectKeysEnumerator(this._coll);
        }
        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (array.Rank != 1)
            {
                throw new ArgumentException(SR.GetString("Arg_MultiRank"));
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", SR.GetString("IndexOutOfRange", new object[] { index.ToString(CultureInfo.CurrentCulture) }));
            }
            if ((array.Length - index) < this._coll.Count)
            {
                throw new ArgumentException(SR.GetString("Arg_InsufficientSpace"));
            }
            IEnumerator enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                array.SetValue(enumerator.Current, index++);
            }
        }
        // Properties
        public int Count
        {
            get
            {
                return this._coll.Count;
            }
        }
        public string this[int index]
        {
            get
            {
                return this.Get(index);
            }
        }
        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }
        object ICollection.SyncRoot
        {
            get
            {
                return ((ICollection) this._coll).SyncRoot;
            }
        }
    }
