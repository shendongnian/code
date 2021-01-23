    public static bool IsValidRomanNumber(string source) {
            bool result = true;
            string[] invalidCouples = { "VV", "LL", "DD", "VX", "VC", "VM", "LC", "LM", "DM", "IC", "IM", "XM" };
            foreach (string s in invalidCouples) {
                if (source.Contains(s)) {
                    result = false;
                    break;
                }
            }
            return result;
        }
 
