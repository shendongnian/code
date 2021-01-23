        // This defines a custom datatype present in our dll.
        [StructLayout(LayoutKind.Sequential)]
        public struct MyDllStruct
        {
            int aValue;
            [MarshalAs(UnmanagedType.Bool)]
            bool anotherValue;
        }
        public static class MyDllInterface
        {
            // The function in the interface can be customized by instead             
            // specifying the EntryPoint in the DllImport-attribute.
            [DllImport("MyDll.dll", EntryPoint = "mydll_function")]
            public static extern int MyDllFunction(
                    int param1,
                // We want this to become a C-style boolean 
                // (false == 0, true != 0)
                    [MarshalAs(UnmanagedType.Bool)]
                    bool param2,
                // We want the dll to write to our struct, and to be  
                // able to get the data written to it back we need to 
                // specify the Out-attribute. If we were just feeding the 
                // parameter to the dll we could just use the In-attribute
                // instead, or combine them if we want to achieve both.
                    [Out, MarshalAs(UnmanagedType.LPStruct)]
                    MyDllStruct resultStruct
                );
            [DllImport("MyDll.dll")]
            // Sometime we need to do a little magic on our own so we let 
            // this function return an IntPtr, and not the struct.
            public static extern IntPtr get_a_pointer_struct();
            // By not defining the EntryPoint-parameter the application 
            // expects that the dll function is named just as the
            // C#-function declaration.
            [DllImport("MyDll.dll")]
            // Here we specify that we are expecting a char-array 
            // back from the function, so the application should
            // marshal it as such.
            [return: MarshalAs(UnmanagedType.LPStr)]
            public static extern string mydll_get_errormsg();
        }
        // This class "converts" the C-style functions
        // into something more similar to the common
        // way C# is usually written.
        public class MyDllWrapper
        {
            // Calls the MyDllInterface.MyDllFunction and returns
            // the resulting struct. If an error occured, an
            // exception is thrown.
            public MyDllStruct CallFunction(int param1, bool param2)
            {
                MyDllStruct result = new MyDllStruct();
                int errorCode = MyDllInterface.MyDllFunction(
                                    param1, param2, result);
                if (errorCode < 0)
                    throw new Exception(String.Format(
                        "We got an error with code {0}. Message: ", 
                        errorCode, MyDllInterface.mydll_get_errormsg()));
                return result;
            }
            // Gets a pointer to a struct, and converts it 
            // into a structure.
            public MyDllStruct GetStruct()
            {
                IntPtr structPtr = MyDllInterface.get_a_pointer_struct();
                return (MyDllStruct)Marshal.PtrToStructure(
                    structPtr, typeof(MyDllStruct));
            }
        }
