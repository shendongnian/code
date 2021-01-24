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
*The performance is not fantastic first time it is used but gets descent afterwards.*
You could also consider a wrapper class implementing the arithmetic operators, holding a reference to an object implementing an interface with Add, Mult etc.. methods,
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
by implementing explicit cast from `T` to `Num<T>` and implicit cast from `Num<T>` to `T` this is reasonably confortable.
If you are after really good performance you might consider making the wrapper class a `struct` (removing the `readonly` sometimes helps also) and using ` [MethodImpl(MethodImplOptions.AggressiveInlining)]` everywhere in the wrapper class.
