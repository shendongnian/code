    public class Array<T>
    {
        private T[] _array { get; set; }
        private int _max { get; set; }
        private int _size { get; set; }
        
        public Array()
        {
            _max = 10;
            _array = new T[_max];
            _size = 0;
        } 
        public T Remove(int i)
        {
            if (i >= _size || i < 0) return default(T);
            var tmp = _array[i];
            for (var j = i; j < _size-1; ++j)
            {
                _array[j] = _array[j + 1];
            }
            _array[_size - 1] = default(T);   
            _size--;
            return tmp;
        }
    }
    Or...
    public T Remove(int i) {
      var tmp = new T[_size-1];
      
      for(var j=0; j < i; ++j) 
      {
         tmp[j] = _array[j];
      }
      var result = _array[i];
      for(var j=i+1; j < _size-1; ++j) 
      {
         tmp[j] = _array[j];
      }
      _array = null;
      _array = tmp;
      return result;
    }
