        [System.Security.SecuritySafeCritical]
        public static unsafe char[] GetChars(int value, char[] chars)
        {
            //TODO: if needed to use accross machines then
            //  this should also use BitConverter.IsLittleEndian to detect little/big endian
            //  and order bytes appropriately
            
            fixed (char* numPtr = chars)
                *(int*)numPtr = value;
            return chars;
        }
        [System.Security.SecuritySafeCritical]
        public static unsafe int ToInt32(char[] value)
        {
            //TODO: if needed to use accross machines then
            //  this should also use BitConverter.IsLittleEndian to detect little/big endian
            //  and order bytes appropriately
            fixed (char* numPtr = value)
                return *(int*)numPtr;
        }
