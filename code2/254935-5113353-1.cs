    [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct TestStruct
        {
            [FieldOffset(8)]
            public TestStruct2 SubStruct;
    
            [FieldOffset(0)]
            public int IntField1;
            [FieldOffset(4)]
            public int IntField2;
            [FieldOffset(8)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public char[] CharArray;
            [FieldOffset(16)]
            public byte SomeByte;        
            
            
            public override string ToString()
            {
                return string.Format("IntField1: {0}\nIntField2: {1}\nCharArray: {2}\nSomeByte: {3}\nSubStruct:\n{{{4}}}", 
                    IntField1, IntField2,  new string(CharArray), SomeByte, SubStruct);
            }
        }
