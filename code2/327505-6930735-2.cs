    [Serializable()] 
    public struct Enumerator : IEnumerator<T>, System.Collections.IEnumerator
    {
        private List<T> list;
        private int index; 
        private int version;
        private T current; 
        internal Enumerator(List<T> list) {
            this.list = list; 
            index = 0;
            version = list._version;
            current = default(T);
        } 
        public void Dispose() { 
        } 
        public bool MoveNext() { 
            List<T> localList = list;
            if (version == localList._version && ((uint)index < (uint)localList._size)) 
            {
                current = localList._items[index]; 
                index++; 
                return true;
            } 
            return MoveNextRare();
        }
        private bool MoveNextRare() 
        {
            if (version != list._version) { 
                ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion); 
            }
            index = list._size + 1;
            current = default(T);
            return false;
        } 
        public T Current { 
            get { 
                return current;
            } 
        }
        Object System.Collections.IEnumerator.Current {
            get { 
                if( index == 0 || index == list._size + 1) {
                     ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen); 
                } 
                return Current;
            } 
        }
        void System.Collections.IEnumerator.Reset() {
            if (version != list._version) { 
                ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
            } 
            index = 0;
            current = default(T); 
        }
    }
