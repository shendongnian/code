    using System;
    
    public class Matrix
    {
        private int row_matrix; //number of rows for matrix
        private int column_matrix; //number of colums for matrix
        private double[,] matrix; //holds values of matrix itself
    
        //create r*c matrix and fill it with data passed to this constructor
        public Matrix(double[,] double_array)
        {
            matrix = double_array;
            row_matrix = matrix.GetLength(0);
            column_matrix = matrix.GetLength(1);
            Console.WriteLine("Contructor which sets matrix size {0}*{1} and fill it with initial data executed.", row_matrix, column_matrix);
        }
    
        //returns total number of rows
        public int countRows()
        {
            return row_matrix;
        }
    
        //returns total number of columns
        public int countColumns()
        {
            return column_matrix;
        }
    
        //returns value of an element for a given row and column of matrix
        public double readElement(int row, int column)
        {
            return matrix[row, column];
        }
    
        //sets value of an element for a given row and column of matrix
        public void setElement(double value, int row, int column)
        {
            matrix[row, column] = value;
        }
    
        public double deterMatrix()
        {
            double det = 0;
            double value = 0;
            int i, j, k;
    
            i = row_matrix;
            j = column_matrix;
            int n = i;
    
            if (i != j)
            {
                Console.WriteLine("determinant can be calculated only for sqaure matrix!");
                return det;
            }
    
            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    det = (this.readElement(j, i) / this.readElement(i, i));
    
                    for (k = i; k < n; k++)
                    {
                        value = this.readElement(j, k) - det * this.readElement(i, k);
    
                        this.setElement(value, j, k);
                    }
                }
            }
            det = 1;
            for (i = 0; i < n; i++)
                det = det * this.readElement(i, i);
    
            return det;
        }
    }
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            Matrix mat03 = new Matrix(new[,]
            {
                {1.0, 2.0, -1.0},
                {-2.0, -5.0, -1.0},
                {1.0, -1.0, -2.0},
            });
    
            Matrix mat04 = new Matrix(new[,]
            {
                {1.0, 2.0, 1.0, 3.0},
                {-2.0, -5.0, -2.0, 1.0},
                {1.0, -1.0, -3.0, 2.0},
                {4.0, -1.0, -3.0, 1.0},
            });
    
            Matrix mat05 = new Matrix(new[,]
            {
                {1.0, 2.0, 1.0, 2.0, 3.0},
                {2.0, 1.0, 2.0, 2.0, 1.0},
                {3.0, 1.0, 3.0, 1.0, 2.0},
                {1.0, 2.0, 4.0, 3.0, 2.0},
                {2.0, 2.0, 1.0, 2.0, 1.0},
            });
    
            double determinant = mat03.deterMatrix();
            Console.WriteLine("determinant is: {0}", determinant);
    
            determinant = mat04.deterMatrix();
            Console.WriteLine("determinant is: {0}", determinant);
    
            determinant = mat05.deterMatrix();
            Console.WriteLine("determinant is: {0}", determinant);
        }
    }
