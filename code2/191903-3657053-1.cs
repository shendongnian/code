    public class SetValueOnce<T>
    {
        public bool _set;
        private T _value;
    
        public SetValueOnce()
        { 
          _value = default(T);
          _set = false;
        }
    
        public SetValueOnce(T value)
        { 
          _value = value;
          _set = true;
        }
    
        public T Value
        {
          get
          {
              if(!_set)
                 throw new Exception("Value has not been set yet!");
              return _value;
          {
          set
          {
             if(_set)
                 throw new Exception("Value already set!");
             _value = value;
             _set = true;
          }
       }
    }
