    public interface ISpecifics
    { 
         void DoSomething();
         string SomeProp { get; }
    }
    public static class Static<S> 
        where S : ISpecifics, new()
    {
      
          public static string ExerciseSpecific()
          {
                var spec = new S();
                spec.DoSomething();
                return spec.SomeProp;
          }
    }
