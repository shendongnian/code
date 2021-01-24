        /// <summary>
        /// Creates a byte array from the passed TypedArray in javascript.
        /// </summary>
        /// <param name="jsStringArray">TypedArray in javascript, like [12, 44, 36, 132, 22, 19, 99]</param>
        /// <returns>Byte array created from passed string</returns>
        private static byte[] StringArrayToByteArrayParser(string jsStringArray ) {
            try{
                // Consider StringBuilder as mutable string.
                // // No need to use heavy Regex
                var sb = new StringBuilder(jsStringArray);
            
                // Removes the first [
                sb.Remove(0,1);
                // Removes the last ]
                sb.Remove(sb.Length-1,1);
            
                // Splits uisng , then converts into byte array
                return sb.ToString().Split(',').Select(byte.Parse).ToArray(); 
            }
            catch(ArgumentOutOfRangeException outOfRange) {
                // Handle etc..
                throw;
            }
            catch(Exception ex) {
                // Here catch your exceptions throw or handle
                throw;
            }
        }
