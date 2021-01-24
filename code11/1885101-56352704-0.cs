    public class StudentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
    }
    public class StudentViewModel
    {
        public  List<StudentInfo> StudentInfos { get; set; }
    }
