    public class Matrix<T> {
         public T[,] values;
     }
     public static class MatrixExtension {
         public static T getCalcResult<T>(this Matrix<T> mat) {
             T result = default(T);
             return result;
         }
     }
     class Program {
         static void Main(string[] args)  {
            Matrix<int> m = new Matrix<int>();
            int aNumber = m.getCalcResult();
            Console.WriteLine(aNumber); //outputs "0"
     }
    
