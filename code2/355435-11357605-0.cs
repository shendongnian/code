    public class Person 
    { 
        public int ID { get; set; } 
        public string Name { get; set; } 
        public virtual Picture Logo { get; set; } 
        public ICollection<Picture> Pictures { get; set; } 
        public ICollection<Note> Notes { get; set; } 
    } 
 
    public class Note 
    { 
        public int ID { get; set; } 
 
        public int OwnerID { get; set; } 
        public string Text { get; set; } 
        [ForeignKey("OwnerId")] 
        public virtual Person Owner { get; set; } 
    } 
 
 
    public class Picture 
    { 
        public int ID { get; set; } 
       
        public virtual int OwnerId { get; set; } 
        public string Path { get; set; } 
        [ForeignKey("OwnerId")] 
        public virtual Person Owner { get; set; } 
    } 
