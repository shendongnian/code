    public class Person : IEquatable<Person>
    {
        public Person(string name, string hometown)
        {
            this.Name = name;
            this.Hometown = hometown;
        }
        public string Name { get; set; }
        public string Hometown { get; set; }
        // can't get much simpler than this!
        public bool Equals(Person other)
        {
            return this.Name == other.Name && other.Hometown == other.Hometown;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();  // see other links for hashcode guidance 
        }
    }
