        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Ninject;
    using Ninject.Activation;
    using Ninject.Syntax;
    
    
        public class Foo
        {
            public int TestProperty { get; set; }
            public Foo(int max = 2000)
            {
                TestProperty = max;
            }
        }
    
        public class Program
        {
    
            public static void Main(string [] arg)
            {
                  using (IKernel kernel = new StandardKernel())
                  {
                     kernel.Bind<Foo>().ToSelf().WithConstructorArgument("max", 1000);
                      var foo = kernel.Get<Foo>();
                      Console.WriteLine(foo.TestProperty); // 1000
                  }
               
            }
        }
