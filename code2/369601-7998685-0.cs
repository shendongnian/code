        public static byte[] ToAnsiMemBytes(this string input)
        {
            int length = input.Length;
            byte[] result = new byte[length];
            try
            {
                IntPtr bytes = Marshal.StringToCoTaskMemAnsi(input);
                Marshal.Copy(bytes, result, 0, length);
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
