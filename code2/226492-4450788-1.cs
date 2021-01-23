    public class StringCollection : List<string>
    {
      public override string ToString()
      {
        //use the pipe character as a delimiter - but this doesn't work
        //if the strings being carried around ccould naturally contain '|'!
        return string.Join("|", this.ToArray());
      }
    }
