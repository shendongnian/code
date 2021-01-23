    class PinCollection : IPinCollection
    {
         private IPin[,] _array;
         #region IEnumerable<int> Members
         public IEnumerator<int> GetEnumerator()
         {
             foreach (IPin i in _array)
                 yield return i;
         }
         #endregion
         #region IEnumerable Members
         System.Collections.IEnumerator
             System.Collections.IEnumerable.GetEnumerator()
         {
             foreach (IPin i in _array)
                 yield return i;
         }
         #endregion
    }
