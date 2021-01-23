        static void Main(string[] args)
        {
            Azurechars a = new Azurechars();
            char[] b = a.ToCharArray(522);
            int i = a.ToInteger(b);
        }
        public class Azurechars
        {
             private static readonly string _azureChars
             = "012456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
             public int ToInteger(char[] chars)
             {
                     int l = AzureChars.IndexOf(chars[0]);
                     int r = AzureChars.IndexOf(chars[1]);
                     return (l * _azureChars.Length) + r;
             }
             public char[] ToCharArray(int value)
             {
                      char l = _azureChars[value / _azureChars.Length];
                      char r = _azureChars[value % _azureChars.Length];
                      return new char[] { l, r };
             }
        }
