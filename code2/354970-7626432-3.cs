    using System;
    using System.Text;
    
    namespace SO7626386
    {
        class Program
        {
            static void Main(string[] args)
            {
                var grades = new int[11];
                // initiate the array using Random class methods
                var grade = new Random();
                for (int j = 1; j < 11; j++)
                {
                    grades[j] = grade.Next(1, 10);
                }
    
                //Read and display the array's elements
                for (int j = 1; j < 11; j++)
                {
                    Console.WriteLine("Student {0} has got: {1} : {2} ", j, grades[j], new StringBuilder().Insert(0,"* ",grades[j]).ToString());
                }   
            }
        }
    }
