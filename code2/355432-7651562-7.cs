        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public virtual Picture Logo { get; set; }
        }
    
        public class Note
        {
            public int ID { get; set; }
            public string Text { get; set; }
        }
    
    
        public class Picture
        {
            public int ID { get; set; }
            public string Path { get; set; }
        }
