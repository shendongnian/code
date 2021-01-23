    static void Main(string[] args)
    {
    
        foo1 s1 = new foo1();
        foo2 s2 = new foo2();
        s1.a = 1;
        s1.b = 2;
    
        s2.c = 3;
        s2.d = 4;
    
        object s3 = s1;
        s2 = CopyStruct<foo2>(ref s3);
    
    }
    
    static T CopyStruct<T>(ref object s1)
    {
        GCHandle handle = GCHandle.Alloc(s1, GCHandleType.Pinned);
        T typedStruct = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
        handle.Free();
        return typedStruct;
    }
    
    struct foo1
    {
        public int a;
        public int b;
    
        public void method1() { Console.WriteLine("foo1"); }
    }
    
    struct foo2
    {
        public int c;
        public int d;
    
        public void method2() { Console.WriteLine("foo2"); }
    }
