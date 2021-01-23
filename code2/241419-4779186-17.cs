    using System;
    using System.Runtime.InteropServices;
    namespace test
    {
        class Program
        {
            [DllImport("lib.dll", EntryPoint = "func1", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern unsafe int func1(char* input, char** data);
    
            [DllImport("lib.dll", EntryPoint = "func1_cleanup", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern unsafe int func1_cleanup(char* data);
    
            static void Main(string[] args)
            {
                string input = "Hello, World!";
                string output;
                int result = func1(input, out output);
            }
    
            private const int S_OK = 0;
    
            public static int func1(string input, out string output)
            {
                unsafe
                {
                    output = null;
                    int result = -1;
                    fixed (char* parray1 = &input.ToCharArray()[0])
                    {
                        //
                        // if you allocating memory in a managed process, you can use this
                        //
                        //char[] array = new char[0xffffff];
                        //fixed(char* parray = &array[0])
                        {
                            //
                            // if you allocating memory in unmanaged process do not forget to cleanup the prevously allocated resources
                            //
                            char* array = (char*)0; 
                            char** parray2 = &array;
                            result = func1(parray1, parray2);
                            if (result == S_OK)
                            {
                                //
                                // if your C++ code returns the ANSI string, you can skip this extraction code block (it can be useful in Unicode, UTF-8, UTF-7, UTF-32, all C# supported encodings)
                                //
                                //byte* self = (byte*)*((int*)parray2);
                                //byte* ptr = self;
                                //List<byte> bytes = new List<byte>();
                                //do
                                //{
                                //    bytes.Add(*ptr++);
                                //}
                                //while (*ptr != (byte)0);
                                //output = Encoding.ASCII.GetString(bytes.ToArray());
                                output = Marshal.PtrToStringAnsi(new IntPtr(*parray2));
                            }
                            func1_cleanup(array);
                        }
                    }
                    return result;
                }
            }
        }
    }
