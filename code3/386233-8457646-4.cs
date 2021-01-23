    public class ParamID
    {
      private readonly string _first; //not necessary, but immutability of keys prevents other possible bugs
      private readonly string _second;
      public ParamID(string first, string second)
      {
        _first = first;
        _second = second;
      }
    }
