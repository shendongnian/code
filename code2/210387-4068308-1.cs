     public  class EnumWrapper<T>
        {
            public static int Num = 1;
            private T _t;
    
            public T EnumValue
            {
                get
                {
                    return _t;
                }
                set
                {
                    _t = value;
                }
            }
    
            public void Assign<U>(U inn) where U : struct, T
            {
                if (typeof(T).IsEnum)
                {
                    EnumValue = inn;
                }
               
                
            }
        }
