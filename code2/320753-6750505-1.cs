    internal class Program
    {
        private struct MyStruct
        {
            //Must be all Int32
            public int Field1, Field2, Field3;
        }
        private static void Main()
        {
            MyStruct str = new MyStruct {Field1 = 666, Field2 = 667, Field3 = 668};
            int[] array = ToArray(str);
            array[0] = 100;
            array[1] = 200;
            array[2] = 300;
            str = FromArray(array);
        }
        private static int[] ToArray(MyStruct str)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                int size = GetInt32ArraySize(str);
                int[] array = new int[size];
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(str, ptr, true);
                Marshal.Copy(ptr, array, 0, size);
                return array;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        private static MyStruct FromArray(int[] arr)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                MyStruct str = new MyStruct();
                int size = GetInt32ArraySize(str);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.Copy(arr, 0, ptr, size);
                str = (MyStruct)Marshal.PtrToStructure(ptr, str.GetType());
                return str;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        private static int GetInt32ArraySize(MyStruct str)
        {
            return Marshal.SizeOf(str) / Marshal.SizeOf(typeof(Int32));
        }
    }
