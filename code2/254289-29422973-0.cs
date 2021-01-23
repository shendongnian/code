    public class Genre
    {
        private string name; // This is the so-called "backing field"
        public string Name // This is your property
        {
            get {return name;}
            set {name = value;}
        }
    }
