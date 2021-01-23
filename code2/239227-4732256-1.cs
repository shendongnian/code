    public MySpecialValue<T> {
        T val;
        bool valSet = false; 
    
        T GetValue() { 
             if (!valSet)
             {
                    val = (T)Convert.ChangeType(DatabaseValue, typeof(T));
                    valSet = true;
             }
             return val;
         }
    
         public string DatabaseValue { get; set; }
    }
