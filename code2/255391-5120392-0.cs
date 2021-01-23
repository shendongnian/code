    class A<T>
            {
                static A()
                {
                    if(!typeof(T).IsEnum)
                    {
                        throw new Exception();
                    }
                }
            }
