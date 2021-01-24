    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // every Subject belongs to exactly one UniversityStudentAssociation using foreign key
        public int UniversityStudentAssociationId {get; set; }
        public virtual UniversityStudentAssociation UniversityStudentAssociation {get; set;}
    }
