    public object[] ObjectAsArray   
    {       
         get 
         { 
             if(_objectsAsArray == null)
                 _objectsAsArray = new object[10];
             return _objectsAsArray;
         }
         set
         {
            _objectsAsArray = value;   
         } 
    }
