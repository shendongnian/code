    public class Person 
    { 
        public int ID { get; set; } 
        public string name { get; set; } 
        public ICollection<Note> Notes { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public Picture logo { get; set; } 
    } 
 
    public class Note 
    { 
        public int ID { get; set; } 
        public string Text { get; set; } 
        public Person Owner { get; set; } 
    } 
 
    public class Picture 
    { 
        public int ID { get; set; } 
        public string Path { get; set; } 
        public Person Owner { get; set; } 
    } 
