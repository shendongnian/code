    public interface IDoubleReturningClass
    {
         double[] DoSomething(params object[] anyNumberOfParams);
    }
    public class Class1 : IDoubleReturningClass
    {
         public double[] DoSomething(params object[] anyNumberOfParams)
         {
             double[] values = new double[1];
             values[0] = 2.0;
             return values;
         }
    }
    public class Class2 : IDoubleReturningClass
    {
         public double[] DoSomething(params object[] anyNumberOfParams)
         {
             double[] values = new double[n];
             for (int c = 0; c < n; c++)
             {
                 values[c] = 3.0;
             }
             return values;
         }
    }
    public class ClassTest
    {
          public double[] Values { get; set; }
          public void SetValues(IDoubleReturningClass item)
          {
                 Values = item.DoSomething( /* Your Params */);
          }
    }
