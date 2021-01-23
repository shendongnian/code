    string _myProp;
    public string MyProp
    { 
       get
       {
         if (String.IsNullOrWhiteSpace(_myProp))
         {
            _myProp =  GetTheValueFromWhereEver();
         }
         return _myProp;
       }
    }
