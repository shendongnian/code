    public static class BitConverterExt
    {
        public static int ToInt32(byte[] arr0, int index0, byte[] arr1, int index1)
        {
            int partRes = (int)((uint)BitConverter.ToUInt16(arr1, index1) << 16);
            return partRes | BitConverter.ToUInt16(arr0, index0);
        }
    }
