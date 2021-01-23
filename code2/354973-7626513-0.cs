    using System;
    using System.Text;
    
    namespace Array_1_10
    {
        class Program
        {
            string stars(int count)
            {
                if (count == 0) return "";
                string st = "*";
                for (int i = 1; i < count; i++)
                {
                    st += " *";
                }
                return st;
            }
            static void Main(string[] args)
            {
                //declar and create an int array object with 10 elements
                int[] grades = new int[10];
                // initiate the array using Random class methods
                Random grade = new Random();
                for (int j = 0; j < 10; j++)
                    grades[j] = grade.Next(1, 9);
                //Read and display the array's elements
                for (int j = 0; j < 10; j++)
                    Console.WriteLine("Student {0} has got: {1} : {2} ", j, grades[j], stars(grades[j]));
            }
        }
    }
