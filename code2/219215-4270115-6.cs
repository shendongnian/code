        public static BitArray ConvertHexToBitArray(string hex)
        {
            Guard.AssertNotNullOrEmpty(hex, "hex");
            Guard.AssertHex(hex, "hex");
            var bits = new BitArray(hex.Length * 4);
            int pos = 0;
            foreach(char c in hex)
            {
                foreach(bool flag in LookupBits(c))
                {
                    bits.Set(pos, flag);
                    pos++;
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
            hexVsBits.Add('2', CreateBitsArray(false, false, true, false));
            hexVsBits.Add('3', CreateBitsArray(false, false, true, true));
            hexVsBits.Add('4', CreateBitsArray(false, true, false, false));
            hexVsBits.Add('5', CreateBitsArray(false, true, false, true));
            hexVsBits.Add('6', CreateBitsArray(false, true, true, false));
            hexVsBits.Add('7', CreateBitsArray(false, true, true, true));
            // complete hex table
            return hexVsBits;
        }
        private static List<bool> CreateBitsArray(bool msb, bool msbMinusOne, bool lsbPlusOne, bool lsb)
        {
            var bits = new List<bool>(4);
            bits.Add(msb);
            bits.Add(msbMinusOne);
            bits.Add(lsbPlusOne);
            bits.Add(lsb);
            return bits;
        }
        private static IEnumerable<bool> LookupBits(char hexValue)
        {
            return _hexVsBits[hexValue];
        }
    }
