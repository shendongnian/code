    public class UniversityStudentAssociation
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        // Every UniversityStudentAssociation belongs to exactly one Student, using foreign key
        public int StudentId {get; set; }
        public virtual Student Student { get; set; }
        // Every UniversityStudentAssociation belongs to exactly one University, using foreign key
        public int UniversityId {get; set; }
        public virtual University University { get; set; }
        // Every UniversityStudentAssociation has zero or more Subjects (one-to-many)
        public IEnumerable<Subject> Subjects { get; set; }
    }
