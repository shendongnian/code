    class Generic<T>
    {
       protected T value;   //it's valid to declare a member whose type is T
       public void Add()
       {
          value + 1.0f;   //invalid, because not all T are allowed to add 
                          //with 0.1f by default
                          //consider T is the type Person
       }
    
       public void Print()
       {
          Type t = typeof(T);   //valid, for all T we can get its type
       }
    }
