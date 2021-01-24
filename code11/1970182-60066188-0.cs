        public class Parent 
    {
        public Menu FullMenu { get; set; }
        public KidDTO SubDTO { get; set; }
    }
    [Bind(Include = "Name")]
    public class KidDTO
    {
        public string Name { get; set;}
        public string Date { get; set;}
        public string Addr { get; set;}
    }
