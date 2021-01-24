    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name="Name")]
        public string StudentName { get; set; }
        public int Age { get; set; }
        public bool isNewlyEnrolled { get; set; }
        public string OnlinePassword { get; set; }
    }
