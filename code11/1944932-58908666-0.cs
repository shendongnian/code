    public class GenericClass<T1> where T1: class, new()
    {
        // <-- I got an error here because I should add same constraint for T2 as it will be used in GenericClass
        public void GenericMethod<T2>(GenericClass<T2> t) 
        // The following line will work fine
        public void GenericMethod<T2>(GenericClass<T2> t) where T2: class, new()
        {
            //do my stuff...
        }
    }
