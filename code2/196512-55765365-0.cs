        public static string Repeat_CharArray_LogN(this string str, int times)
        {
            int limit = (int)Math.Log(times, 2);
            char[] buffer = new char[str.Length * times];
            int width = str.Length;
            Array.Copy(str.ToCharArray(), buffer, width);
            for (int index = 0; index < limit; index++)
            {
                Array.Copy(buffer, 0, buffer, width, width);
                width *= 2;
            }
            Array.Copy(buffer, 0, buffer, width, str.Length * times - width);
            return new string(buffer);
        }
