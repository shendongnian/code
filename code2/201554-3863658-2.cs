    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    
    class StructTranslator {
        public static bool Read<T>(byte[] buffer, int index, ref T retval) {
            if (index == buffer.Length) return false;
            int size = Marshal.SizeOf(typeof(T));
            if (index + size > buffer.Length) throw new IndexOutOfRangeException();
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try {
                IntPtr addr = (IntPtr)((long)handle.AddrOfPinnedObject() + index);
                retval = (T)Marshal.PtrToStructure(addr, typeof(T));
            }
            finally {
                handle.Free();
            }
            return true;
        }
    
        public bool Read<T>(Stream stream, ref T retval) {
            int size = Marshal.SizeOf(typeof(T));
            if (buffer == null || size > buffer.Length) buffer = new byte[size];
            int len = stream.Read(buffer, 0, size);
            if (len == 0) return false;
            if (len != size) throw new EndOfStreamException();
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try {
                retval = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally {
                handle.Free();
            }
            return true;
        }
    
        private byte[] buffer;
    }
