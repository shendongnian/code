    public static class Static
    {
          public static string ExerciseSpecific<S>()
              where S : ISpecifics, new()
          {
                var spec = new S();
                spec.DoSomething();
                return spec.SomeProp;
          }
    }
