    public class MyEnum
    {
      public static readonly MyEnum A = new MyEnum("A");
      public static readonly MyEnum B = new MyEnum("B");
      public static readonly MyEnum C = new MyEnum("C");
      public override string ToString()
      {
        return Value;
      }
      protected MyEnum(string value)
      {
        this.Value = value;
      }
    
      public string Value { get; private set; }
    }
    
    public sealed class MyDerivedEnum : MyEnum
    {
      public static readonly MyDerivedEnum D = new MyDerivedEnum("D");
    
      private MyDerivedEnum(string value)
        : base(value)
      {
      }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEnum blah = MyEnum.A;
            System.Console.WriteLine(blah);
            blah = MyDerivedEnum.D;
            System.Console.WriteLine(blah);
        }
    }
