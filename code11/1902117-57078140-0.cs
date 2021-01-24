            [DllImport(LibraryName, EntryPoint = "FooBar", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern void Bar(IntPtr data);
            static void Main(string[] args)
            {
                Foo data = new Foo();
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(data));
                Marshal.StructureToPtr(data, ptr, true);
                Bar(ptr);
            }
            public struct Foo
            {
                private uint x;
                private uint y;
            }
