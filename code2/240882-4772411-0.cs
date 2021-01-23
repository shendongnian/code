    public class Person
    {
      public string Nicknames { private get; set; }
      public string[] ArrayOfNicknames
      {
        get
        {
            return Nicknames.Split(<your_delimiter>);
        }
      }
    }
