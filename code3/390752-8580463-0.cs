    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public void Persist()
        {
            EmployeeDAO.Persist(this);
        }
    }
    public class Assignment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    
        public void Persist()
        {
            AssignmentDAO.Persist(this);
        }
    }
    public static class EmployeeDAO
    {
        public static int Persist(Employee emp)
        {
            // insert if new, else update
        }
    
        public static Employee Get(int empId)
        {
            // return the ugly employee
        }
        .....
    }
    public static class AssignmentDAO
    {
        public static int Persist(Assignment ass)
        {
            // insert if new, else update
        }
        .....
    }
