    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // every Student has zero or more UniversityStudentAssociations (one-to-many)
        public virtual ICollection<UniversityStudentAssociation> UniversityStudentAssociations {get; set;}
    }
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // every University has zero or more UniversityStudentAssociations (one-to-many)
        public virtual ICollection<UniversityStudentAssociation> UniversityStudentAssociations {get; set;}
    }
