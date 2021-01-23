    class Class1_xy<T1,T2> : ITemplate1<T1,T2>
        where T2 : ITemplate2<T1,T2>
        where T1 : ITemplate1<T1,T2>
    {
        public T2 t2
        {
            get; set; }
    }
    
    class Class2_xy<T1, T2> : ITemplate2<T1, T2>
        where T2 : ITemplate2<T1, T2>
        where T1 : ITemplate1<T1, T2>
    {
        public T1 t1
        { get; set; }
    }
    
    class ClassBoth_xy<T1, T2> : ITemplate1<T1,T2>, ITemplate2<T1, T2>
        where T2 : ITemplate2<T1, T2>
        where T1 : ITemplate1<T1, T2>
    {
        public T1 t1
        { get; set; }
    
        public T2 t2
        { get; set; }
    }
    
