    public interface IWorld
    {
        string Hello(string value);
    }
    string code = @"namespace MyNamespace
    {
      class Temp : IWorld
      {
          public string Hello(string value)
          {
              return "World " + value;
          }
      }
    }";
    Compiler compiler = new Compiler();
    compiler.AddType(typeof(string));
    compiler.Compile(code);
    var obj = compiler.CreateInstance<IWorld>();
    string result = obj.Hello("World!");
