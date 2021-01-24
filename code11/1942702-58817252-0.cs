    public class LUID
    {
        private static readonly RNGCryptoServiceProvider RandomGenerator 
                   = new RNGCryptoServiceProvider();
        private static readonly char[] ValidCharacters = 
                   "ABCDEFGHJKLMNPQRSTUVWXYZ23456789".ToCharArray();
        public const int DefaultLength = 6;
        private static int counter = 0;
    
        public static string Generate(int length = DefaultLength)
        {
            var randomData = new byte[length];
            RandomGenerator.GetNonZeroBytes(randomData);
    
            var result = new StringBuilder(DefaultLength);
            foreach (var value in randomData)
            {
                counter = (counter + value) % (ValidCharacters.Length - 1);
                result.Append(ValidCharacters[counter]);
            }
            return result.ToString();
        }
    }
