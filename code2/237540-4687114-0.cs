    public class Token
    {
      public TokenType Type { get ; private set ; }
      public string    Text { get ; private set ; }
      public int       LineNumber { get ; private set ; }
      public int       Column     { get ; private set ; }
    }
    public enum TokenType
    {
      Keyword : 1 ,
      Integer ,
      String  ,
      Whitespace ,
      Comment ,
      ... 
    }
