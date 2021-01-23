    public static class Extensions {
        public static byte[] ToByteArray(this object obj) {
            var size = Marshal.SizeOf(data);
            var bytes = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(data, ptr, false);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);
            return bytes;
       }
        public static string Serialize(this object obj) {
            return JsonConvert.SerializeObject(obj);
       }
    }
