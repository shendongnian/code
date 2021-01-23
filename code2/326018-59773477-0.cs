    public interface MyInterface<T> where T : ParamA
    {
      void Execute(T paramA);
    }
    public interface ParamA
    {
      string ParameterA { get; }
    }
    public class myClass1 : MyInterface<myClass1.myParamA>
    {
      public class myParamA : ParamA
      {
        public string ParameterA { get; set; }
      }
      public void Execute(myParamA a)
      {
        Console.WriteLine(a.ParameterA);
      }
    }
    public class myClass2 : MyInterface<myClass2.myParamsAb>
    {
      public class myParamsAb : ParamA
      {
        public string ParameterA { get; set; }
        public int ParameterB { get; set; }
      }
      public void Execute(myParamsAb ab)
      {
        Console.WriteLine(ab.ParameterA);
        Console.WriteLine(ab.ParameterB.ToString());
      }
    }
