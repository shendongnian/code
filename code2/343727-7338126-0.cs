    class Foo<T>
        where T : AbstractBaseClass, new()
    {
        T M( Bar bar )
        {
            T t = new T();
            if ( typeof (T) == T1 )
            {
                t.SomeProperty = bar.SomeMethod();
            }
            else if ( typeof (T) == T2 )
            {
                t.SomeProperty = bar.SomeOtherMethod();
            }
            else if ( typeof (T) == T3 )
            {
                t.SomeProperty == bar.YetAnotherMethod();
            }
        }
    }
