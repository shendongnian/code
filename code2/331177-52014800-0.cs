    using System;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.Net;
    
    namespace ConsoleApp1
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct MarshalMe
        {
            private UInt16 _param1;
            private UInt32 _param2;
            private UInt16 _param3;
            private UInt16 _param4;
            public ushort Param1 { get => _param1;  }
            public uint Param2 { get => _param2;  }
            public ushort Param3 { get => _param3; }
            public ushort Param4 { get => _param4; }
        }
    
        class Program
        {
           
            static void Main(string[] args)
            {
     
                byte[] bytes = new byte[] {0x00, 0x03, 0x00, 0x00,  0x00, 0x04, 0x00, 0x05, 0x00, 0x00 };
    
                var metoo = rotateStruct<MarshalMe>(stamp<MarshalMe>(bytes));
    
                Console.WriteLine("{0}-{1}-{2}", metoo.Param1, metoo.Param2, metoo.Param3);
    
                Console.ReadKey();
            }
    
            private static T stamp<T>(byte[] bytes)
            {
                var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                var structure = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                handle.Free();
    
                return (T)structure;
            }
    
            private static T rotateStruct<T>(object value)
            {
                FieldInfo[] myFieldInfo;
                Type myType = typeof(T);
                // Get the type and fields of FieldInfoClass.
                myFieldInfo = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
    
                foreach (var s in myFieldInfo)
                {
                    if (s.FieldType.Name == "UInt16"){
                        UInt16 u16 = (ushort)s.GetValue(value);
                        u16 = (ushort)IPAddress.HostToNetworkOrder((short)u16);
                        s.SetValue(value,u16 );
                    }
                    else if(s.FieldType.Name == "UInt32")
                    {
                        UInt32 u32 = (uint)s.GetValue(value);
                        u32 = (uint)IPAddress.HostToNetworkOrder((int)u32);
                        s.SetValue(value, (object)u32);
                    }
                    else if (s.FieldType.Name == "UInt64")
                    {
                        UInt64 u64 = (ushort)s.GetValue(value);
                        u64 = (ulong)IPAddress.HostToNetworkOrder((long)u64);
                        s.SetValue(value, u64);
                    }
    
                }
                
                return (T)value;
            }      
    
        }
    }
