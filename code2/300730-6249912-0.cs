    public class MyBooleanStateClass
    { 
      public bool? setTrue { get; set; }
      public bool? setFalse { get; set; }
      public bool? Invert { get; set; }
    }
    private static void doSomething(MyBooleanStateClass state)
    {
       if(state.setTrue.HasValue())
         // do something with setTrue
       // repeat for all the others
    }
