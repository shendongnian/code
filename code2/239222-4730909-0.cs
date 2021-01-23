    public class MyClass 
    {
    ...
    }
    
    Public class MyClass<T> : MyClass
    {
      T val;
      bool valSet; 
      public T GetValue<T> () { 
            if (!valSet)
            {
                val = (T)Convert.ChangeType(DatabaseValue, typeof(T))};
                valSet = true;
            }
            return val;
        }
    }
