       class Program
        {
            static void Main(string[] args)
            {
                DateTime date = DateTime.Now;
                DataBase db = new DataBase();
                var results = (from s in db.Student
                               join sc in db.StudentContest on s.StudentID equals sc.StudentId
                               join c in db.Contest.Where(x => x.ContextDate < date) on sc.ContextID equals c.ContestId
                               select new { StudentID = s.StudentID, StudentName = s.StudentName, StudentSurName = s.StudentSurName, Point = s.Point }
                               ).ToList();
            }
        }
        public class DataBase
        {
            public List<StudentContest> StudentContest { get; set; }
            public List<Student> Student { get; set; }
            public List<Contest> Contest { get; set; }
        }
        public class StudentContest
        {
            public string StudentId { get; set;}
            public string ContextID { get; set;}
        }
        public class Student
        {
            public string StudentID { get; set;}
            public string StudentName { get; set;}
            public string StudentSurName { get; set;}
            public string Point { get; set;}
        }
        public class Contest
        {
            public string ContestId { get; set;}
            public DateTime ContextDate { get; set; }
        }
