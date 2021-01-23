    public class SomeClass : IEquatable<SomeClass>
    {
        public bool IsChecked { get; set; }
        public string Title { get; set; }
    
        public bool Equals(SomeClass other)
        {
            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;
    
            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;
    
            //Check whether SomeClass's properties are equal.
            return Title.Equals(other.Title);
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public override int GetHashCode()
        {
            //Get hash code for the Title field if it is not null.
            int hashSomeClassTitle = Title == null ? 0 : Title.GetHashCode();
    
            //Calculate the hash code for SomeClass.
            return hashSomeClassTitle;
        }
    }
