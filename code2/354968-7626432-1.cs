    using System;
    using System.Text;
    
    namespace Array_1_10
    {
        class Program
        {
            static void Main(string[] args)
            {
                //declar and create an int array object with 5 elements
    
                
                int[] grades = new int[11];
                // initiate the array using Random class methods
                Random grade = new Random();
                for (int j = 1; j < 11; j++)
                    grades[j] = grade.Next(1, 9);
    
                //Read and display the array's elements
                for (int j = 1; j < 11; j++)
                {
                    string tempStars = ""; //initialize string each time
                    for (int lp = 0 ; lp < grades[j] ; lp++)) { // build the string
                        tempStars += "*" + " ";
                    }
                    Console.WriteLine("Student {0} has got: {1} : {2} ", j, grades[j], tempStars);
                }   
            }
        }
    }
