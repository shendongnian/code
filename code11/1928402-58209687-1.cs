    static void Test()
    {
      var v = new List<EmbeddedInt>();
      var a = new EmbeddedInt(2);
      v.Add(a);
      v[0].Value = 4;
      Console.WriteLine(a);  // Display 4
    }
    public class EmbeddedInt
    {
      public int Value { get; set; }
      public override string ToString()
      {
        return Value.ToString();
      }
      public EmbeddedInt(int value)
      {
        Value = value;
      }
    }
