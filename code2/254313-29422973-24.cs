    public class Genre
    {
        private string name; // This is the backing field
        public string Name   // This is your property
        {
            get => name;
            set => name = value;
        }
    }
