    private class ListEnumerator : IEnumerator 
    {
		private object[] _objects;
		public ListEnumerator(object[] objects)
		{
			this._objects = objects;
		}
    	private int _currentIndex = -1; 
 
        public bool MoveNext()
        {
            _currentIndex++;
 
            return (_currentIndex < this._objects.Length); 
        }
 
        public object Current
        { 
            get
            {
                try
                {
                    return this._objects[_currentIndex];
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
