        public class Person
        {
            public int ID { get; set; }
            public string name { get; set; }
            public virtual Picture logo { get; set; }
        }
    
        public class Note
        {
            [Key, ForeignKey("Person")]
            public int PersonID { get; set; }
            public string Text { get; set; }
            public virtual Person Owner { get; set; }
        }
    
    
        public class Picture
        {
            [Key, ForeignKey("Person")]
            public virtual int PersonId { get; set; }
            public string Path { get; set; }
            public virtual Person Owner { get; set; }
        }
