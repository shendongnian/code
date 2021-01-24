    public class GenericClass<T>
    {
      static public T Value
      {
        get { return _Value.Value; }
        set { _Value.Value = value; }
      }
      static private SharedStaticValue<T> _Value
        = new SharedStaticValue<T>();
    }
    internal class Class1 : GenericClass<int>
    {
    }
    internal class Class2 : GenericClass<int>
    {
    }
    internal class SharedStaticValueTest
    {
      SharedStaticValue<int> value = new SharedStaticValue<int>();
      public void RunTest()
      {
        Action<string> write = (str) =>
        {
          Console.WriteLine(str);
          Console.WriteLine("  this.SharedStaticValue<int> = " + value.Value);
          Console.WriteLine("  GenericClass<double> = " + GenericClass<double>.Value);
          Console.WriteLine("  GenericClass<int> = " + GenericClass<int>.Value);
          Console.WriteLine("  Class1 extend GenericClass<int> = " + Class1.Value);
          Console.WriteLine("  Class2 extend GenericClass<int> = " + Class2.Value);
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
        write("Set Class2 extend GenericClass<int>.Value = 50");
      }
    }
