    public class Student
    {
        public string Admission_date { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Semester { get; set; }
        public string HOD { get; set; }
    }
    
    public class Data
    {
        public List<Student> students { get; set; }
        public int remaining { get; set; }
    }
    
    public class RootObject
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }
