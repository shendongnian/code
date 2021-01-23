    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Math.Util
    {
        class UtilMath
        {
            public static string hex2binary(string hexvalue)
            {
                // Convert.ToUInt32 this is an unsigned int
                // so no negative numbers but it gives you one more bit
                // it much of a muchness 
                // Uint MAX is 4,294,967,295 and MIN is 0
                // this padds to 4 bits so 0x5 = "0101"
                return String.Join(String.Empty, hexvalue.Select(c => Convert.ToString(Convert.ToUInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            }
        }
    }
