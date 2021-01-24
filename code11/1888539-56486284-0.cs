C#
class Matrix<T>
{
     public static Matrix<T> operator + (Matrix<T> a, Matrix<T> b)
     {
         // check a.M = b.M, a.N = b.N
         var c = new Matrix<T>(a.M, a.N);
         for (var i = 0; i < a.N ; i ++)
         {
             for (var i = 0; i < a.N ; i ++)
             {
                  dynamic x = a[i, j], y = b[i, j];
                  c[i,j] = (T) (x + y);
             }
         }
         return c;
    }
}
You could consider a wrapper class implementing the arithmetic operators, holding a reference to an object implementing an interface with Add, Mult etc.. methods,
C#
public interface IRingElem<T>   // strangely recurring pattern
     where T : IRingElem<T>
{
    T Add(T);
}
public class Num<T>
     where T : IRingElem<T>
{
    private readonly T elem;
    public static Num<T> operator + (Num<T> a, Num<T> b)
    {
        return new Num<T>(a.elem.Add(b.elem));
    }
}
