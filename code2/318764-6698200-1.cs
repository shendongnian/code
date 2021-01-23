    public class Matrix<T,TArithmetic>
      where TArithmetic:struct, IArithmetic<T>
    {
      private static readonly TArithmetic arithmetic=new TArithmetic();
    
      void DoStuff()
      {
        arithmetic.Add(1,2);
      }
    }
