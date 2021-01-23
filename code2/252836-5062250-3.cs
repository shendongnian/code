    static class Horspool
    {
        private static int[] BuildBadSkipArray(byte[] needle)
        {
            const int MAX_SIZE = 256;
            int[] skip = new int[MAX_SIZE];
            var needleLength = needle.Length;
            for (int c = 0; c < MAX_SIZE; c += 1)
            {
                skip[c] = needleLength;
            }
            var last = needleLength - 1;
            for (int scan = 0; scan < last; scan++)
            {
                skip[needle[scan]] = last - scan;
            }
               
            return skip;
        }
        public static bool ContainsHorspool(this byte[] haystack, byte[] needle)
        {
            var hlen = haystack.Length;
            var nlen = needle.Length;
            var badCharSkip = BuildBadSkipArray(needle);
            var last = nlen - 1;
            int offset = 0;
            int scan = nlen;
            while (offset + last < hlen)
            {
                for (scan = last; haystack[scan + offset] == needle[scan]; scan = scan - 1)
                {
                    if (scan == 0)
                    {
                        return true;
                    }
                }
                offset += badCharSkip[haystack[scan + offset]];
                
            }
            return false;
        }
    }
