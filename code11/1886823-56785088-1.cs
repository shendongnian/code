        public class Assignment
        {
            public DateTime Date { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Score { get; set; }
            public double Weight { get; set; }
            public int AssignmentId { get; set; }
            public int SubjectId { get; set; }
            public virtual Subject Subject { get; set; }
        }
