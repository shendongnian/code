        /// <summary>
        /// Creates a byte array from the passed TypedArray in javascript.
        /// </summary>
        /// <param name="jsStringArray">TypedArray in javascript, like [12, 44, 36, 132, 22, 19, 99]</param>
        /// <returns>Byte array created from passed string</returns>
        private static byte[] StringArrayToByteArrayParser(string jsStringArray ) {
            try{
                
                // // No need to use heavy Regex
                var sb = jsStringArray.Substring(1, jsStringArray.Length - 2);
            
                
            
                // Splits using , then converts into byte array
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
