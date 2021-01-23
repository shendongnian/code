    public class Matrix<T>  where T : new() {
         public T[,] values;
     }
     public static class MatrixExtension {
         public static T getCalcResult<T>(this Matrix<T> mat)  where T : new() {
             T result = new T();
             return result;
         }
     }
     class Program {
         static void Main(string[] args)  {
            Matrix<int> m = new Matrix<int>();
            int aNumber = m.getCalcResult();
            Console.WriteLine(aNumber); //outputs "0"
     }
    
