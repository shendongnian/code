    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public List<string> OrderedProperties => new List<string> { "LastName", "FirstName", "Id" };
    }
    
    public class DataAccess
    {
        public void SaveStudentToExcel()
        {
            var student = new Student(); // instead of new this should be your object filled with real data.
            foreach (var propName in student.OrderedProperties)
            {
                var val = student.GetType().GetProperty(propName).GetValue(student, null);
    
                // new cell in excel => with val and propName then save
            }
        }
    }
