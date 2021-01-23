    class Test
    {
        public static void Convert<T>(ref T arg)
        {
            object o = arg; // box so SetValue will work
            Type argType = arg.GetType();
            foreach (FieldInfo fi in argType.GetFields())
            {
                if (fi.FieldType == typeof(System.Int32))
                    fi.SetValue(o, IPAddress.HostToNetworkOrder((int)fi.GetValue(o)));
                else if (fi.FieldType == typeof(System.Int16))
                    fi.SetValue(o, IPAddress.HostToNetworkOrder((short)fi.GetValue(o)));
            }
            arg = (T)o; // unbox and set value of ref parameter
        }
        public static void RunTest()
        {
            StructA a = new StructA() { I1 = 0x11223344, S1 = 0x1122 };
            Console.WriteLine("a: {0}", a);
            Convert(ref a);
            Console.WriteLine("a: {0}", a);
        }
    }
    public struct StructA
    {
        public short S1;
        public int I1;
        public override string ToString()
        {
            return string.Format("StructA[S1=0x{0:X4}, I1=0x{1:X8}]", S1, I1);
        }
    }
    public struct StructB
    {
        public short S2;
        public int I2;
        public override string ToString()
        {
            return string.Format("StructB[S2=0x{0:X4}, I2=0x{1:X8}]", S2, I2);
        }
    }
