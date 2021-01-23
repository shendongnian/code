    interface A<out T> { }
    
    class B { }
    class C : A<B> { }
    
    class D : B { }
    class E : A<D> { }
    
    static class X
    {
        public static A<B> GetThing(bool f)
        {
            if (f)
            {
                return new E();
            }
            return new C();
        }
    }
