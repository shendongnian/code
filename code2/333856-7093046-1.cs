     private t _value;
     private MyType(t val)
     {
          _value = val;
     }
     public static implicit operator MyType<t>(t obj)
     {
         return new MyType<t>(obj);
     }
