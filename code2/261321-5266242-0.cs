    public class MySplitter
    {
         public MySplitter(string split)
         {
             var results = string.Split(',');
             NamedPartA = results[0];
             NamedpartB = results[1];
         }
        
         public string NamedPartA { get; private set; }
         public string NamedPartB { get; private set; }
    }
