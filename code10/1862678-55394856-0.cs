    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
            
        [ForeignKey("Standard")]
        public int StandardRefId { get; set; }
        public Standard Standard { get; set; }
    }
    
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        
        public ICollection<Student> Students { get; set; }
    }
