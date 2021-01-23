        public static void CopyTo(this StringBuilder source, StringBuilder dest)
        {
            char[] buffer = new char[Math.Min(source.Length, 1024)];
            CopyTo(source, dest, buffer);
        }
        public static void CopyTo(this StringBuilder source, StringBuilder dest, char[] buffer)
        {
            for (int i = 0; i < source.Length; i += buffer.Length)
            {
                int charCount = Math.Min(source.Length - i, buffer.Length);
                source.CopyTo(i, buffer, 0, charCount);
                dest.Append(buffer, 0, charCount);
            }
        }
