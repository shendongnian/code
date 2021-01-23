                int[] grades = { 59, 82, 70, 56, 92, 98, 85 };
    
                IEnumerable<int> topThreeGrades =
                    grades.OrderByDescending(grade => grade)**.Take(3)**;
    
                Console.WriteLine("The top three grades are:");
                foreach (int grade in topThreeGrades)
                {
                    Console.WriteLine(grade);
                }
