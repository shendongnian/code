    class ReferenceType<T>
    {
        public T Value { get; set }
        public ReferenceType(T value) { this.Value = value; }
    }
    var v1 = new ReferenceType<short>(1);
    var v2 = new ReferenceType<short>(2);
    var vs = new ReferenceType<short>[2] { v1, v2 };
    v1.Value = 1024;
    v2.Value = 512;
    Console.WriteLine(vs[0].Value);
    Console.WriteLine(vs[1].Value);
