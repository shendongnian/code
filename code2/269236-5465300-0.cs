    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct FileRecord
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
        public char[] ID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
        public char[] Name;
        public int Gender;
        public float height;
        //...
    }
    class Program
    {
        protected static T ReadStruct<T>(Stream stream)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
            stream.Read(buffer, 0, Marshal.SizeOf(typeof(T)));
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T typedStruct = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return typedStruct;
        }
        static void Main(string[] args)
        {
            using (Stream stream = new FileStream(@"test.bin", FileMode.Open, FileAccess.Read))
            {
                FileRecord fileRecord = ReadStruct<FileRecord>(stream);
            }
        }
