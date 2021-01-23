    //FOR DEBUG/TEST ONLY
    using System.Runtime.InteropServices;
    namespace ByteStructCast1
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            unsafe struct StructTest//4B
            {
                [MarshalAs(UnmanagedType.U2)]
                public ushort item1;//2B
                public fixed byte item2[2];//2B =2x 1B
            }
            static void Main(string[] args)
            {
                //managed byte array
                byte[] DB1 = new byte[7];//7B more than we need. byte buffer usually is greater.
                DB1[0] = 2;//test data |> LITTLE ENDIAN
                DB1[1] = 0;//test data |
                DB1[2] = 3;//test data
                DB1[3] = 4;//test data
                unsafe //OK we are going to pin unmanaged struct to managed byte array
                {
                    fixed(byte* db1 = DB1) //db1 is pinned pointer to DB1 byte[] array
                    {
                        //StructTest t1 = *(StructTest*)db1;    //does not change DB1/db1
                        //t1.item1 = 11;                        //does not change DB1/db1
                        db1[0] = 22;                            //does CHANGE DB1/db1
                        DB1[0] = 33;                            //does CHANGE DB1/db1
                        StructTest* ptest = (StructTest*)db1;   //does CHANGE DB1/db1
                        ptest->item1 = 44;                      //does CHANGE DB1/db1
                        ptest->item2[0]++;                      //does CHANGE DB1/db1
                        ptest->item2[1]--;                      //does CHANGE DB1/db1
                    }
                }
            }
        }
    }
