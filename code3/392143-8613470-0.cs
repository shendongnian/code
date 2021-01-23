    public class Student
    {
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // changed this to results of the exams taken
        // you can still get exam via ExamResult -> Exam
        public virtual ICollection<ExamResult> ExamsTaken { get; set; }
    }
    public class Exam
    {
        public int ExamID { get; set; }
        public int CourseID { get; set; }
        public string ExamTitle { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual Course Course { get; set; }
        // used to be ICollection of exam statuses, but that got moved to the
        // ExamResult class
        public virtual ICollection<ExamResults> Results { get; set; }
    }
    public class ExamResult
    {
        public int ExamID { get; set; }
        public int StudentID { get; set; }
        public decimal? Score { get; set; }
        // all your results should have a status right? im assuming
        // unfinished or not started exams have statuses
        // so this shouldn't be nullable
        public int ExamStatusID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Exam Exam { get; set; }
    }
