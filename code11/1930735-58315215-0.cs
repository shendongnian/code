    public bool DataIsValid(string s, Type someNumType) {
    d = 0; // a class member variable
    
       if(someNumType == typeof(int))
       {
         d = int.Parse(s);
         return true;
       }
       if(someNumType == typeof(double))
       {
         d = double.Parse(s);
         return true;
       }
       if(someNumType == typeof(decimal))
       {
         d = decimal.Parse(s);
         return true;
       }
    
       return false;
    }
