        public class Person
        {
            public int ID { get; set; }
            public string name { get; set; }
            public virtual Picture logo { get; set; }
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
