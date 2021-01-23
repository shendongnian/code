    public class Foo {
      public string Bar { get; set; }
    }
    
    //somewhere else...
    container.RegisterType<Foo>(new InjectionProperty("Bar", "oh hai!"));
    
    var foo = container.Resolve<Foo>();
    Console.WriteLine(foo.Bar); //"oh hai!"
