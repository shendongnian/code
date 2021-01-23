       // Binding
       public sealed class FooModule: NinjectModule 
       {
         public opverride void Load() 
         {
            Bind<IReadOnlyList<IFoo>>().ToMethod(c=>new IFoo[]
            {
              c.Kernel.Get<FooType1>(),
              c.Kernel.Get<FooType2>(),
               ...
            });
          }
       }
    
       // Injection target
       public class InjectedClass {
          public InjectedClass(IReadOnlyList<IFoo> foos) { ;}
       }
