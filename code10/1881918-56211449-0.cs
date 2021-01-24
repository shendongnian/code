    public static class ImageMetaExtensions
    {
        public static void SetMaxAperture(this Image image, uint numerator, uint denominator)
        {
            SetMetaDataItem(image, MAX_APERTURE, (short)TagTypes.RATIONAL, GetPairUnsigned32Integer(numerator, denominator));
        }
        public static void SetExposureTime(this Image image, uint numerator, uint denominator)
        {
            SetMetaDataItem(image, EXPOSURE_TIME, (short)TagTypes.RATIONAL, GetPairUnsigned32Integer(numerator, denominator));
        }
        public static void SetUserComment(this Image image, string text)
        {
            SetMetaDataItem(image, USER_COMMENT, (short)TagTypes.ASCII, GetNullTerminatedString(text));
        }
        public static void Set35mmFocalLength(this Image image, short focalLength)
        {
            SetMetaDataItem(image, FOCALLENGTH_35MM, (short)TagTypes.SHORT, BitConverter.GetBytes(focalLength));
        }
        public enum TagTypes : short
        {
            BYTE = 1, // 8 bit unsigned integer
            ASCII = 2,
            SHORT = 3, // 16-bit unsigned integer
            LONG = 4, // 32-bit unsigned integer
            RATIONAL = 5, // two unsigned longs - first numerator, second denominator
            UNDEFINED = 6, // any value depending on field definition
            SLONG = 7, // signed 32-bit
            SRATIONAL = 10 // signed pair of 32-bit numerator/denominator
        }
        
        private static void SetMetaDataItem(Image image, int id, short type, byte[] data)
        {
            PropertyItem anyItem = image.PropertyItems[0];
            anyItem.Id = id;
            anyItem.Len = data.Length;
            anyItem.Type = type;
            anyItem.Value = data;
            image.SetPropertyItem(anyItem);
        }
        
        private static byte[] GetPairUnsigned32Integer(uint numerator, uint denominator)
        {
            return BitConverter.GetBytes(numerator).Concat(BitConverter.GetBytes(denominator)).ToArray();
        }
    
        private static byte[] GetNullTerminatedString(string text)
        {
            return Encoding.ASCII.GetBytes(text + "\0");
        }
        private const int EXPOSURE_TIME = 0x829A;      
        private const int USER_COMMENT = 0x9286;
        private const int MAX_APERTURE = 0x9205;
        private const int FOCALLENGTH_35MM = 0xA405;
    }
