    public class Rand
    {
       private static Random Generator = new Random();
       public static T Get<T>(T[] items) //Choose a random char from string
          =>  items[Generator.Next(items.Length)];
    
    }
    private static string Letters = "abcdefghijklmnopqrstuvwxyz";
    private static string Numbers = "1234567890";
    private static string Symbols = "!@#$%^&*()";
    
    public enum Options
    {
       Upper,Lower, Numbers, Symbols
    }
    
    public static IEnumerable<char> Generate(int size, params Options[] options)
    {
       for (var i = 0; i < size; i++)
       {
          switch (Rand.Get(options))
          {
             case Options.Upper: yield return char.ToUpper(Rand.Get(Letters.ToCharArray())); break;
             case Options.Lower: yield return Rand.Get(Letters.ToCharArray()); break;
             case Options.Numbers: yield return Rand.Get(Numbers.ToCharArray()); break;
             case Options.Symbols: yield return Rand.Get(Symbols.ToCharArray());break;
          }
       }
    }
