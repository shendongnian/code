    public class SomeClass : IEquatable<SomeClass>
    {
        public bool IsChecked { get; set; }
        public string Title { get; set; }
    
        public bool Equals(SomeClass other)
        {
           return this.Title == other.Title;
        }
    }
