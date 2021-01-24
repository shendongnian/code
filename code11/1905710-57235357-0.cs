    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp3
    {
        struct Student
        {
            string number;
            string fullName; // both name and surname separated with space
            int score;
    
            public Student(string new_number, string new_fullName, int new_score)
            {
                number   = new_number;
                fullName = new_fullName;
                score    = new_score; 
            }
    
            public string toString()
            {
                return "Hello " + fullName + ", Studentnumber: " + number + " with Score: " + score.ToString();
            }
    
            public int getScore()
            {
                return score;
            }
        }
        class Program
        {
            private static List<Student> students = new List<Student>();
    
            private static void addNewStudent(Student student)
            {
                students.Add(student);
            }
    
            private static string getStudentNumber()
            {
                Console.Write("Enter your student number:");
                string studentNumber = Console.ReadLine();
                if (studentNumber.Length <= 8 && int.TryParse(studentNumber, out int n) == true)
                {
                    return studentNumber;
                }
                else
                {
                    Console.WriteLine("Insufficient digits entered");
                    return getStudentNumber();
                }
            }
    
            private static string getStudentFullName()
            {
                Console.Write("Enter your name and surname: ");
                string fullName = Console.ReadLine();
                if(fullName.Contains(" "))
                {
                    return fullName;
                }
                else
                {
                    Console.WriteLine("You must enter both name and surname");
                    return getStudentFullName();
                }
    
            }
    
            private static int getStudentScore()
            {
                Console.Write("Enter a test score: ");
                try
                {
                    int score = Convert.ToInt32(Console.ReadLine());
                    return score;
                }
                catch
                {
                    Console.WriteLine("Score must be integer");
                    return getStudentScore();
                }
            }
            static void getStudentInformation()
            {
                Console.WriteLine("Get new student information");
                string number = getStudentNumber();
                string fullName = getStudentFullName();
                int score = getStudentScore();
                Student newStudent = new Student(number, fullName, score);
                addNewStudent(newStudent);
                Console.WriteLine(newStudent.toString());
                
    
            }
            static void Main(string[] args)
            {
                while(true)
                {
                    Console.Write("Enter A to Add new student, G to Get students list info and average score: ");
                    string res = Console.ReadLine();
                    if(res == "A")
                    {
                        getStudentInformation();
                    }
                    else if (res == "G")
                    {
                        if(students.Count == 0)
                        {
                            Console.WriteLine("Student Number in the List: 0");
                        }
                        else
                        {
                            int scoreSum = 0;
                            foreach(Student student in students)
                            {
                                scoreSum += student.getScore();
                            }
    
                            float averageScore = scoreSum / students.Count;
                            Console.WriteLine("Average score is: " + averageScore.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have to type A or G");
                    }
                }
            }
        }
    }
