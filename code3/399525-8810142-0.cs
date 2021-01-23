    public class NullByteComparer : IComparer<byte?>
    {
        public int Compare(byte? a, byte? b)
        {
            if (a == b)
                return 0;
            if (a == null)
                return 1;
            if (b == null)
                return -1;
            return return a < b ? -1 : 1;
        }
    }
 
