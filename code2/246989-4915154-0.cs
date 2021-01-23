    public string StackingText
    {
       get 
       { 
          return _Model.StackingRate == 0
             ? null
             : _Model.StackingText; 
       }
    }
