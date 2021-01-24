     public static string unWrap(SecureString input_secure_string)
            {
                if (input_secure_string == null) return null;
                IntPtr _pointer = IntPtr.Zero; //Initiating a integer which can store a C++ pointer. Intptr is a type in C# which can store C or C++ pointer types.
                try
                {
                    _pointer = Marshal.SecureStringToGlobalAllocUnicode(input_secure_string); // Native code method which converts secure string to string
                    return Marshal.PtrToStringUni(_pointer); 
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally //Most important key part is this. After we return the converter string, we dispose the pointer from memory.
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(_pointer);
                }
            }
