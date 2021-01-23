    class MyClass {
      public bool Value { get; set; }
      public MyClass() {
        Value = true;
      }
      public static implicit operator bool(MyClass m) {
        return m != null && m.Value;
      }
    }
    class Program {
      public static void Main() {
        var myClass = new MyClass();
        if (myClass) { // MyClass can be treated like a Boolean
          Console.WriteLine("myClass is true");
        }
        else {
          Console.WriteLine("myClass is false");
        }
      }
    }
