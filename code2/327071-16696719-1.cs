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
