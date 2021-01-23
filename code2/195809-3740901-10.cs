        static void Main(string[] args)
        {
            AzureCharConverter a = new AzureCharConverter();
            char[] b = a.ToCharArray(522);
            int i = a.ToInteger(b);
        }
        public class AzureCharConverter
        {
             private static readonly string _azureChars
             = "012456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
             public int ToInteger(char[] chars)
             {
                     int l = _azureChars.IndexOf(chars[0]);
                     int r = _azureChars.IndexOf(chars[1]);
                     return (l * _azureChars.Length) + r;
             }
             public char[] ToCharArray(int value)
             {
                      char l = _azureChars[value / _azureChars.Length];
                      char r = _azureChars[value % _azureChars.Length];
                      return new char[] { l, r };
             }
        }
