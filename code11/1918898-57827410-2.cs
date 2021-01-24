`
using System;
namespace test2
{
    public class Student
    {
        public Student(string name, string lastName, int grade)
        {
            this.Name = name;
            this.Lastname = lastName;
            this.Grade = grade;
        }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Grade { get; set; }
        public void Print()
        {
            Console.WriteLine($"Name: {this.Name} | Lastname: {this.Lastname} | Grade: {this.Grade}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student studentA = new Student("John", "Park", 20);
            studentA.Print();
            Student studentB = new Student("Joe", "Dor", 10);
            studentB.Print();
            Student studentC = new Student("Rose", "Hancook", 7);
            studentC.Print();
            Console.ReadLine();
        }
    }
}
`
Again, let's review.
If, as JoshuaRobinson pointed out, the methods need to be inside of the `Student` class, then this will meet that requirement.
the class 'Student' now has a method called a `Constructor`, which means it has the same name as the class itself.
`
        public Student(string name, string lastName, int grade)
        {
            this.Name = name;
            this.Lastname = lastName;
            this.Grade = grade;
        }
`
This will be called anytime you do a `new Student()` and it takes the names and the grade.  It then creates a new `Student`.
The `Print()` method has also been moved into the `Student` class, so it no longer needs to accept a student as a parameter.
