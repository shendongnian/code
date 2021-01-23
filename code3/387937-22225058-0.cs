        public static string Encrypt(string str, int n)
        {
            return string.Join("", str.Select(x => Encrypt(x, n)));
        }
        public static string Decrypt(string str, int n)
        {
            return string.Join("", str.Select(x => Decrypt(x, n)));
        }
        public static char Encrypt(char chr, int n)
        {
            int x = chr - 65;
            return (char)((65) + ((x + n) % 26));
        }
        public static char Decrypt(char chr, int n)
        {
            int x = chr - 65;
            return (char)((65) + ((x - n) % 26));
        }
