    public class MyCollection : ICollection<string>
    {
        //using System;
        //using System.Collections;
        //using System.Collections.Generic;
        //using System.Collections.ObjectModel;
        //using System.Diagnostics.Contracts;
        private readonly ICollection<string> _inner = new Collection<string>();
        #region ICollection<string> Members
        public void Add(string item)
        {
            int oldCount = Count;
            _inner.Add(item);
            Contract.Assume(Count >= oldCount);
        }
        public void Clear()
        {
            _inner.Clear();
            Contract.Assume(Count == 0);
        }
        public bool Contains(string item)
        {
            bool result = _inner.Contains(item);
            // without the following assumption:
            // "ensures unproven: !Contract.Result<bool>() || this.Count > 0"
            Contract.Assume(!result || (Count > 0));
            return result;
        }
        public void CopyTo(string[] array, int arrayIndex)
        {
            Contract.Assume(arrayIndex + Count <= array.Length);
            _inner.CopyTo(array, arrayIndex);
        }
        public bool Remove(string item)
        {
            return _inner.Remove(item);
        }
        public int Count
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() == _inner.Count);
                return _inner.Count;
            }
        }
        public bool IsReadOnly
        {
            get { return _inner.IsReadOnly; }
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
