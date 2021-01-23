    class Program
    {
        [DllImport("mydll.dll")]
        internal static extern void Foo(string arg1);
        
        static void Main()
        {
            Program.Foo ("Pierre");
        }
    }
