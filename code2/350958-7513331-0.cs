        public static class MD5Gen
        {
            static MD5 hash = MD5.Create();
            public static string Encode(string toEncode)
            { 
                return Convert.ToBase64String(
                hash.ComputeHash(Encoding.UTF8.GetBytes(toEncode)));
            }
        }
