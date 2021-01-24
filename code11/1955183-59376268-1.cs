    public class Dinosaur
    {
         public string Name { get; set; }
         public string Type {get set;}
        //your class stuff here
        public override string ToString()
        {
             return $"Name: {Name}, Type: {Type}";
        }
    }
