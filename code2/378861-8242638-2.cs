    using MathNet.Numerics.LinearAlgebra.Double;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            double[,] A = new double[3, 3];
    
            A[0, 0] = 1;
            A[0, 1] = 0.2;
            A[0, 2] = 1;
            A[1, 0] = 1.5;
            A[1, 1] = -1.2;
            A[1, 2] = 1.1;
            A[2, 0] = 0.45;
            A[2, 1] = 2.1;
            A[2, 2] = -0.76;
    
            Matrix XA = new DenseMatrix(A);
            Matrix XB = new DenseMatrix(A);
    
            Matrix C = (Matrix)(XA * XB); // throws a TypeLoadException 
        }
    }
