        class Class1_x<T2> : ITemplate1<Class1_x<T2>, T2>
            where T2 : ITemplate2<Class1_x<T2>, T2>
        {
            public T2 t2
            {
                get; set;
            }
        }
    
        class Class2_x<T1> : ITemplate2<T1, Class2_x<T1>>
            where T1 : ITemplate1<T1, Class2_x<T1>>
        {
            public T1 t1
            {
                get;
                set;
            }
        }
