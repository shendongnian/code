        public static byte MakeHexSigned(byte value)
        {
            if (value > 255 / 2)
            {
                value = -1 * (255 + 1) + value;
            }
            return value;
        }
