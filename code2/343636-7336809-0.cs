       unsafe class Program {
    
            [System.Runtime.InteropServices.DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
            private static extern void MoveMemory(Maintenance_Param* dest, Maintenance_Param* src, int size);
    
            static  void Main(string[] args) {
    
                Maintenance_Param p1 = new Maintenance_Param();
                p1.bCommand = 2;
                p1.bSubCommand = 3;
                p1.usDataLength = 3;
                p1.myStruct1 = new MyStruct1();
    
                Maintenance_Param p2 = new Maintenance_Param();
    
                // can be shortened - i know 
                Maintenance_Param* p1Ptr = &p1;
                Maintenance_Param* p2Ptr = &p2;
                MoveMemory(p2Ptr, p1Ptr, sizeof(Maintenance_Param));
            }
        }
    
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
        public struct Maintenance_Param {
    
            // fields should be private and be accessed over properties ...
            [System.Runtime.InteropServices.FieldOffset(0)]
            public byte bCommand;
            [System.Runtime.InteropServices.FieldOffset(1)]
            public byte bSubCommand;
            [System.Runtime.InteropServices.FieldOffset(2)]
            public ushort usDataLength;
            [System.Runtime.InteropServices.FieldOffset(4)]
            public MyStruct1 myStruct1;
            [System.Runtime.InteropServices.FieldOffset(4)]
            public MyStruct2 myStruct2;
        }
    
        public struct MyStruct1 {
            int value;
        }
    
        public struct MyStruct2 {
            int value;
        }
