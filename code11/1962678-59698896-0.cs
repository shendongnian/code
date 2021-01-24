            static unsafe void Main(string[] args)
        {
            //Console.WriteLine(sizeof(System.Void));
            var o = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(void));
            Console.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(o));
            Console.Read();
            //Console.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(System.Void));
        }
