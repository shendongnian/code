        public class Subject
        {
            public int SubjectId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string GradeEarned { get; set; }
            public string GradeOverall { get; set; }
            public List<Assignment> Assignments { get; set; }
        }
