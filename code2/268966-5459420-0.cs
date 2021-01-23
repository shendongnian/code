    public class MyCollection : ICollection<string>
    {
        //using System;
        //using System.Collections;
        //using System.Collections.Generic;
        //using System.Collections.ObjectModel;
        private readonly ICollection<string> _inner = new Collection<string>();
        #region ICollection<string> Members
        public void Add(string item)
        {
            _inner.Add(item);
        }
        public void Clear()
        {
            _inner.Clear();
        }
        public bool Contains(string item)
        {
            return _inner.Contains(item);
        }
        public void CopyTo(string[] array, int arrayIndex)
        {
            _inner.CopyTo(array, arrayIndex);
        }
        public bool Remove(string item)
        {
            return _inner.Remove(item);
        }
        public int Count
        {
            get { return _inner.Count; }
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
