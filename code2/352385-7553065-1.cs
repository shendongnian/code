    public class Employee : Person
    {      
        public int EmployeeNumber { get; set; }
        public override bool IsNobody
        {
            return base.IsNobody || EmployeeNumber == -1;
        }
    }
