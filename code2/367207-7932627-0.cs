    public class Foo<T, U> where U : Foo<T, U>
    {     
        public class Bar
        {
            private T t;
            private U u;
        }
    }
        
    public class Baz
    {
    }
        
    public class FooBaz : Foo<Baz, FooBaz>
    {
    }
