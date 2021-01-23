    public class SortCollection<T> : IList<SortItem<T>>
    {
        public SortCollection(IList<T> sortList)
        {
            InnerList = sortList;
        }
    
        private IList<T> InnerList = null;
    
        public T this[int key] 
        { 
            get 
            {
                return InnerList[key]; 
            } 
            set 
            {
                SwapCount++;
                InnerList[key] = value; 
            } 
        }
    
        private int _SwapCount = 0;
        public int SwapCount
        {
            private set
            {
                _SwapCount = value;
            }
            get
            {
                return _SwapCount;
            }
        }
    
        public void ResetSwapCount()
        {
            _SwapCount = 0;
        }
    
    
    }
