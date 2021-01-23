    public class Employee
    {
         [Constructors go here]
         public int EmployeeID { get; private set; }
         public string EmployeeName { get; private set; }
         public List<Child> Children { get; private set; } // Or Collection, Array, etc.
    }
