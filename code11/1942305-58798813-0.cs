    class Program
    {
        static void Main(string[] args)
        {
            char lettergrade = StudentGrades.ReportCard();
        }
    }
    public static class StudentGrades
    {
        public static char ReportCard()
        {
            char[] letterGrade = { 'A', 'B', 'C', 'D', 'F' };
            Console.WriteLine("Enter midterm grade");
            double midtermGrade = Convert.ToInt32(Console.ReadLine());
            if (midtermGrade >= 0 && midtermGrade <= 100)
            {
                Console.WriteLine("Enter final exam grade");
                double finalExamGrade = Convert.ToInt32(Console.ReadLine());
                if (finalExamGrade >= 0 && midtermGrade <= 100)
                {
                    double gradeAverage = ((midtermGrade + finalExamGrade) / 2);
                    if (gradeAverage >= 90 && gradeAverage <= 100)
                    {
                        return letterGrade[0];
                    }
                    else if (gradeAverage >= 80 && gradeAverage <= 90)
                    {
                        return letterGrade[1];
                    }
                    else if (gradeAverage >= 70 && gradeAverage <= 80)
                    {
                        return letterGrade[2];
                    }
                    else if (gradeAverage >= 60 && gradeAverage <= 70)
                    {
                        return letterGrade[3];
                    }
                    else if (gradeAverage < 60)
                    {
                        return letterGrade[4];
                    }
                }
                else
                {
                    try
                    {
                        throw new System.ArgumentException();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Grades must be between 0 - 100");
                        return letterGrade[0];
                    }
                }
            }
            else
            {
                try
                {
                    throw new System.ArgumentException();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Grades must be between 0 - 100");
                    return letterGrade[0];
                }
            }
            return letterGrade[0];
        }
    }
