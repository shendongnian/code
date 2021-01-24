l7jvgw77rf
e8h6i6bg1q
2jz8alaf7q
2k1rh5byqo
esgcmdy0f5
sjmhvbilu4
v29bm4gzym
4nznljdwv7
xk9c8s7u6f
wzev2msf0s
If you plan to generate long strings you may use StringBuilder instead of string concatenation, that avoids the copy of strings items each time you add a char:
    using System.Text;
    private string letters = "abcdefghijklmnopqrstuvwxyz0123456789";
    public string GetRandomLetterNumbers(int nrLetterNumbers)
    {
      var builder = new StringBuilder();
      for ( int i = 0; i < nrLetterNumbers; i++ )
      {
        builder.Append(letters[random.Next(0, letters.Length)]);
      }
      return builder.ToString();
    }
