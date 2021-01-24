    private class ListEnumerator : IEnumerator 
    {
		private List _list;
		public ListEnumerator(List list)
		{
			this._list = list;
		}
    	private int _currentIndex = -1; 
 
        public bool MoveNext()
        {
            _currentIndex++;
 
            return (_currentIndex < this._list._objects.Length); 
        }
 
        public object Current
        { 
            get
            {
                try
                {
                    return this._list._objects[_currentIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
    		}
        }
 
        public void Reset()
        {
            _currentIndex = -1;
        }
    }
