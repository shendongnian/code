    public class WorkAssignment {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual Location Location { get; set; }
        public int LocationId { get; set; }
    }
    [Table("vwWorkAssignmentByDate")]
    public class WorkAssignmentDate 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual Location Location { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
    }
