    public class GenericClass<T>
    {
      static public int Value
      {
        get { return _Value.Value; }
        set { _Value.Value = value; }
      }
      static private SharedStaticValue<int> _Value
        = new SharedStaticValue<int>(Guid.Parse("521ecaba-2a5e-43f2-90e0-fda38a32618c"));
    }
    internal class Class1 : GenericClass<int>
    {
    }
    internal class Class2 : GenericClass<string>
    {
    }
    internal class SharedStaticValueTest
    {
      private SharedStaticValue<int> value 
        = new SharedStaticValue<int>(Guid.Parse("{E838689A-3B2C-4BFB-A15C-2F1B5D65F1DE}"));
      public void RunTest()
      {
        Action<string> write = (str) =>
        {
          Console.WriteLine(str);
          Console.WriteLine("  this.SharedStaticValue<int> = " + value.Value);
          Console.WriteLine("  GenericClass<double> = " + GenericClass<double>.Value);
          Console.WriteLine("  GenericClass<int> = " + GenericClass<int>.Value);
          Console.WriteLine("  Class1 extend GenericClass<int> = " + Class1.Value);
          Console.WriteLine("  Class2 extend GenericClass<string> = " + Class2.Value);
          Console.WriteLine();
        };
        write("Default values");
        value.Value = 10;
        write("Set this.SharedStaticValue<int>.Value = 10");
        GenericClass<double>.Value = 20;
        write("Set GenericClass<double>.Value = 20");
        GenericClass<int>.Value = 30;
        write("Set GenericClass<int>.Value = 30");
        Class1.Value = 40;
        write("Set Class1 extend GenericClass<int>.Value = 40");
        Class2.Value = 50;
        write("Set Class2 extend GenericClass<string>.Value = 50");
      }
    }
