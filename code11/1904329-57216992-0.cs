    class Program
    {
        static void Main(string[] args)
        {
            int noOfStudents, totalMarks, position = 1;
            string studentName, engMarks, mathMarks, computerMarks;
            Console.Write("Enter Total Students: ");
            noOfStudents = Convert.ToInt32(Console.ReadLine());
            string[,] studentInfo = new string[noOfStudents, 5];
            studentInformation(studentInfo);
            // Sorting
            for (int i = 0; i < noOfStudents; i++)
            {
                for (int j = 0; j < (noOfStudents - 1); j++)
                {
                    if (Int32.Parse(studentInfo[j, 4]) < Int32.Parse(studentInfo[j +1, 4]))
                    {
                        // Temporary element used to store the sorted data
                        string[,] temp = new string[1, 5];
                        // Exchange every grade + name from the higher one to the lesser one
                        for (int k = 0; k < 5; k++)
                        {
                            // Copy one to temp element
                            temp[0, k] = studentInfo[j, k];
                            // Copy the other in the first one
                            studentInfo[j, k] = studentInfo[j + 1, k];
                            // Copy back temp in the other one
                            studentInfo[j + 1, k] = temp[0, k];
                        }
                    }
                }
            }
            for (int i = 0; i < noOfStudents; i++)
            {
                Console.WriteLine("Student Name: {0}, Position: {1}, Total: {2}/300", studentInfo[i, 0], position, studentInfo[i, 4]);
            }
            
            Console.ReadKey();
            void studentInformation(string[,] a)
            {
                for (int i = 0; i < noOfStudents; i++)
                {
                    Console.Write("Enter Student Name: ");
                    studentName = Console.ReadLine();
                    studentInfo[i, 0] = studentName;
                    Console.Write("Enter English Marks(Out of 100): ");
                    engMarks = Console.ReadLine();
                    studentInfo[i, 1] = engMarks;
                    Console.Write("Enter Maths Marks(Out of 100): ");
                    mathMarks = Console.ReadLine();
                    studentInfo[i, 2] = mathMarks;
                    Console.Write("Enter Computer Marks(Out of 100): ");
                    computerMarks = Console.ReadLine();
                    studentInfo[i, 3] = computerMarks;
                    Console.WriteLine("************************************");
                    totalMarks = (int.Parse(engMarks) + int.Parse(mathMarks) + int.Parse(computerMarks));
                    studentInfo[i, 4] = totalMarks.ToString();
                }
            }
        }
    }
