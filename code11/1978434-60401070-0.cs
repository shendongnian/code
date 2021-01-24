    public class Employee
    {
        public Employee(string n, float s)
        {
            Console.WriteLine("Hello Mr. {0}, Your Salary is {1}", n, s);
        }
    }
  
    public class Director : Employee
    {
        public void Salary(string name, float salary)
            : base(name, salary) // Make sure you include this line
        {
            Console.WriteLine("Your Salary is: " + s);
        }
    }
