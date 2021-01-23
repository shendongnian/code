    public partial class College
    {
        public College()
        {
            CollegeDetails = new CollegeDetails();
            Students = new List<Student>();
            StaffDetails = new StaffDetails();
        }
        public CollegeDetails CollegeDetails;
        public List<Students> Students;
        public StaffDetails StaffDetails;
    }
    public partial class Student
    {
        public Student()
        {
            StudentDetails = new StudentDetails();
            Marks = new List<Mark>();
        }
        public StudentDetails StudentDetails ;
        public List<Marks> Marks;
    }
