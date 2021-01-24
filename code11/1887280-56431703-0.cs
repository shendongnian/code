        static void Main(string[] args)
        {
            SHA512Cng sha = new SHA512Cng();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(Password_field.Password));
            var hexSignature = ToHexString(hash);
        }
        public static string ToHexString(byte[] array)
        {
            return string.Concat(Array.ConvertAll(array, b => b.ToString("x2")));
        }
