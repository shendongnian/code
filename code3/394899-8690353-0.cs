     class Bind : IEquatable<Bind> {
         public string x { get; set; }
         public string y { get; set; }
         public bool Equals(Bind other)
         {
             return x == other.x && y == other.y; 
         } 
    }
