        static void Main(string[] args)
        {
            char[] b = AzureCharConverter.ToCharArray(522);
            int i = AzureCharConverter.ToInteger(b);
        }
        public static class AzureCharConverter
        {
             private static readonly string _azureChars
             = "012456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
             public static int ToInteger(char[] chars)
             {
                     int l = _azureChars.IndexOf(chars[0]);
                     int r = _azureChars.IndexOf(chars[1]);
                     return (l * _azureChars.Length) + r;
             }
             public static char[] ToCharArray(int value)
             {
                      char l = _azureChars[value / _azureChars.Length];
                      char r = _azureChars[value % _azureChars.Length];
                      return new char[] { l, r };
             }
        }
