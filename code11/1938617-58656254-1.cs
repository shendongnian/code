    class A<T> 
    where T : IComparable, IConvertible
    { 
    }
    static void test<TInstance, TParam>(TParam param)
    where TInstance : A<TParam>
    where TParam : IComparable, IConvertible
    {
    }
