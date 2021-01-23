        [StructLayout(LayoutKind.Sequential)]
        public struct FileEntry
        {
            public readonly byte Value1;
            //you may need to play around with this one
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public readonly string Filename;
            public readonly byte Value2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public readonly byte[] FileOffset;
            public readonly float whatever;
        }
        public static T RawDataToObject<T>(byte[] rawData) where T : struct
        {
            var pinnedRawData = GCHandle.Alloc(rawData,
                                               GCHandleType.Pinned);
            try
            {
                // Get the address of the data array
                var pinnedRawDataPtr = pinnedRawData.AddrOfPinnedObject();
                // overlay the data type on top of the raw data
                return (T) Marshal.PtrToStructure(pinnedRawDataPtr, typeof(T));
            }
            finally
            {
                // must explicitly release
                pinnedRawData.Free();
            }
        }
        private static void Main(string[] args)
        {
            byte[] data =;//from file stream or whatever;
            //usage
            FileEntry entry = RawDataToObject<FileEntry>(data);
        }
