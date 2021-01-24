    public interface IMultiValueGenerator
    {
      void GenerateValue(ITimeMulti multi, int multiplier);
    }
    public class Multi2Generator : IMultiValueGenerator
    {
      public void GenerateValue(ITimeMulti multi, int multiplier)
      {
        multi.Mult2 = multi.Source * multiplier;
      }
    }
    public static class MultiGeneratorFactory
    {
       public static IMultiValueGenerator GetGenerator(...)
       {
          if (condition)
            return new Multi2Generator();
          // etc
       }
    }
