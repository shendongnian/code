        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
        struct SendData
        {
            public UInt32 CmdID;          // 4 bytes       
            public UInt32 code;           // 4 bytes        
            private char _description0;  // 2 bytes
            private char _description1;  // 2 bytes
            private char _description2;  // 2 bytes
            private char _description3;  // 2 bytes
            public string Description
            {
                get
                {
                    return _description0.ToString() + _description1.ToString() + _description2.ToString() + _description3.ToString();
                }
                set
                {
                    _description0 = value.ToCharArray(0, 4)[0];
                    _description1 = value.ToCharArray(0, 4)[1];
                    _description2 = value.ToCharArray(0, 4)[2];
                    _description3 = value.ToCharArray(0, 4)[3];
                }
            }
            public byte[] ToByteArray()
            {
                int length = Marshal.SizeOf(this);
                byte[] byteArray = new byte[length];
                IntPtr pointer = Marshal.AllocHGlobal(length);
                Marshal.StructureToPtr(this, pointer, true);
                Marshal.Copy(pointer, byteArray, 0, length);
                Marshal.FreeHGlobal(pointer);
                return byteArray;
            }
        }
        static void Main(string[] args)
        {
            var sendData = new SendData();
            sendData.Description = "Hello World";
            var byteArray = sendData.ToByteArray();
            foreach (byte b in byteArray)
                Console.WriteLine($"Byte {b}");
        }
