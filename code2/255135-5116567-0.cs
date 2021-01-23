    class X   
       {   
         private int y; //not strictly necessary but good for documentation
    
        public X(int number)
        {
            y = GetYValueFromDB();  //we assume the value from DB is already valid
                                    
        }
    
        public int Y { 
           get{ return y}; 
           set { 
           if (ComplexValidation(value)
             {
               RaiseOnYPropertyChanged();
               y = value;
             }
            }
    
    
        }
