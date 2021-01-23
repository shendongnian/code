    class MyClass<T1, T2>
        where T1 : ITemplate1<T1, T2>, new()
        where T2 : ITemplate2<T1, T2>, new()
    {
        public MyClass()
        {
            T1 _t1 = new T1();
            T2 _t2 = new T2();
            bool isValid = (_t1 is Class1_1 && _t2 is Class2_1) ||
                           (_t1 is Class1_2 && _t2 is Class2_2);
            if( !isValid )
                throw new Exception("Inconsistent types have been used to instantiate MyClass.");
        }
        ...
    }
