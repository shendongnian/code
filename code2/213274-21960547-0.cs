    static class Program
    {
        static unsafe void Main()
        {
            Console.WriteLine("64-bit: {0}", Environment.Is64BitProcess);
            Console.WriteLine("Layout of OneField: {0}", typeof(OneField).StructLayoutAttribute.Value);
            Console.WriteLine("Layout of Composite: {0}", typeof(Composite).StructLayoutAttribute.Value);
            Console.WriteLine("Size of Composite: {0}", sizeof(Composite));
            var local = default(Composite);
            Console.WriteLine("L: {0:X}", (long)(&(local.L)));
            Console.WriteLine("M: {0:X}", (long)(&(local.M)));
            Console.WriteLine("N: {0:X}", (long)(&(local.N)));
        }
    }
    [StructLayout(LayoutKind.Auto)]  // also try removing this attribute
    struct OneField
    {
        public long X;
    }
    struct Composite   // has layout Sequential
    {
        public byte L;
        public double M;
        public OneField N;
    }
