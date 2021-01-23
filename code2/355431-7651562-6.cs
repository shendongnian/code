        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public virtual Picture Logo { get; set; }
            public virtual ICollection<Picture> Pictures { get; set; }
            public virtual ICollection<Note> Notes { get; set; }
        }
    
        public class Note
        {
            public int ID { get; set; }
            [ForeignKey("Person")]
            public int OwnerID { get; set; }
            public string Text { get; set; }
            public virtual Person Owner { get; set; }
        }
    
    
        public class Picture
        {
            public int ID { get; set; }
            [ForeignKey("Person")]
            public virtual int OwnerId { get; set; }
            public string Path { get; set; }
            public virtual Person Owner { get; set; }
        }
