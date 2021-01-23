        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public virtual Picture Logo { get; set; }
        }
    
        public class Note
        {
            [Key, ForeignKey("Person")]
            public int OwnerID { get; set; }
            public string Text { get; set; }
            public virtual Person Owner { get; set; }
        }
    
    
        public class Picture
        {
            [Key, ForeignKey("Person")]
            public virtual int OwnerId { get; set; }
            public string Path { get; set; }
            public virtual Person Owner { get; set; }
        }
