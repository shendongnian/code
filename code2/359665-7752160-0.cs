    private PropertyChangedEventHandler _propertyChanged;
    public PropertyChangedEventHandler PropertyChanged
    {
       add 
       { 
         // intercept here
         _propertyChanged += value; 
       }
       remove 
       { 
         // intercept here
         _propertyChanged -= value; 
       }
    }
