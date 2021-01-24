    public class Student
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int Grade { get; set; }
        public void PrintStudentInfo()
        {
            Console.WriteLine("First Name: {0} | Last Name: {1} | Grade: {2}", FirstName, Lastname, Grade);
        }
    }
