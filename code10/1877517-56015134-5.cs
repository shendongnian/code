    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public override string ToString()
        {
            return $"StudentID={StudentID} StudentName={StudentName}";
        }
    }
