      /// Converts an IEEE floating number to its string representation (4 or 8 ascii codes).
        /// Useful for SAS XPORT files format.
        /// </summary>
        /// <param name="from_">IEEE number</param>
        /// <param name="padTo8_">When true, output is 8 chars rather than 4</param>
        /// <returns>Printable string according to hardware's endianness</returns>
        public static string Float2IbmAsAsciiCodes(float from_, bool padTo8_ = true)
        {
            StringBuilder sb = new StringBuilder();
            string s;
            byte[] bytes = BitConverter.GetBytes(Float2Ibm(from_)); // big endian order
            if (BitConverter.IsLittleEndian)
            {
                // Revert bytes order
                for (int i = 3; i > -1; i--)
                    sb.Append(Convert.ToChar(bytes[i]));
                s = sb.ToString();
                if (padTo8_)
                    s = s.PadRight(8, '\0');
                return s;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                    sb.Append(Convert.ToChar(bytes[i]));
                s = sb.ToString();
                if (padTo8_)
                    s = s.PadRight(8, '\0');
                return s;
            }
        }
