    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public Student(int rNo, string name)
        {
            this.RollNo = rNo;
            this.Name = name;
        }
        public Student()
        {
        }
    }
    public class Subject
    {
        public int SubjectNo { get; set; }
        public string Type { get; set; }
        public Subject(int sNo, string sType)
        {
            this.SubjectNo = sNo;
            this.Type = sType;
        }
        public Subject()
        {
        }
    }
