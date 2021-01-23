        public static BitArray ConvertHexToBitArray(string hex)
        {
            Guard.AssertNotNullOrEmpty(hex, "hex");
            Guard.AssertHex(hex, "hex");
            BitArray bits = new BitArray(hex.Length * 4);
            int pos = bits.Length;
            foreach(char c in hex)
            {
                foreach(bool flag in LookupBits(c))
                {
                    bits[pos--] = flag;
                }
            }
            return bits;
        }
        private static readonly Dictionary<char, List<bool>> _hexVsBits = CreateHexLookupTable();
        private static Dictionary<char, List<bool>> CreateHexLookupTable()
        {
            var hexVsBits = new Dictionary<char, List<bool>>();
            
            hexVsBits.Add('0', CreateBitsArray(false, false, false, false));
            hexVsBits.Add('1', CreateBitsArray(false, false, false, true));
            // complete hex table
            return hexVsBits;
        }
        private static List<bool> CreateBitsArray(bool msb, bool msbMinusOne, bool lsbPlusOne, bool lsb)
        {
            var bits = new List<bool>(4);
            bits[0] = lsb;
            bits[1] = lsbPlusOne;
            bits[2] = msbMinusOne;
            bits[3] = msb;
            return bits;
        }
        private static IEnumerable<bool> LookupBits(char hexValue)
        {
            return _hexVsBits[hexValue];
        }
