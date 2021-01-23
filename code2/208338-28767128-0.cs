    using System;
    using System.IO;
    
    public static class MemoryStreams
    {
        public static MemoryStream Append(this MemoryStream stream, byte value, out bool done)
        {
            try
            {
                stream.WriteByte(value);
                done = true;
            }
            catch { done = false; }
            return stream;
        }
    
        public static MemoryStream Append(
            this MemoryStream stream, byte[] value,
            out bool done,
            uint offset = 0, Nullable<uint> count = null)
        {
            try
            {
                var rLenth = (uint)((value == null) ? 0 : value.Length);
    
                var rOffset = unchecked((int)(offset & 0x7FFFFFFF));
    
                var rCount = unchecked((int)((count ?? rLenth) & 0x7FFFFFFF));
    
                stream.Write(value, rCount, rOffset);
                done = true;
            }
            catch { done = false; }
            return stream;
        }
    }
