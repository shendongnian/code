    public abstract class Column<T>
    {
      public abstract T readValue(MyParser myParser);
    }
    public class IntColumn : Column<int>
    {
      public override int readValue(MyParser myParser)
      {
        return myParser.readInt();
      }
    }
