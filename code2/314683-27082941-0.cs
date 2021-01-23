    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    namespace FontUtil
    {
        public static class Reader
        {
            public static T Read<T>(BinaryReader reader, bool fileIsLittleEndian = false)
            {
                Type type = typeof(T);
                int size = Marshal.SizeOf(type);
                byte[] buffer = new byte[size];
                reader.Read(buffer, 0, size);
                if (BitConverter.IsLittleEndian != fileIsLittleEndian)
                {
                    FieldInfo[] fields = type.GetFields();
                    foreach (FieldInfo field in fields)
                    {
                        int offset = (int)Marshal.OffsetOf(type, field.Name);
                        int fieldSize = Marshal.SizeOf(field.FieldType);
                        for (int b = offset, t = fieldSize + b - 1; b < t; ++b, --t)
                        {
                            byte temp = buffer[t];
                            buffer[t] = buffer[b];
                            buffer[b] = temp;
                        }
                    }
                }
                GCHandle h = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                T obj = (T)Marshal.PtrToStructure(h.AddrOfPinnedObject(), type);
                h.Free();
                return obj;
            }
        }
    }
