    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override int GetHashCode()
        {
            return (Name == null ? 0 : Name.GetHashCode()) ^ Age.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }
        public bool Equals(Person other)
        {
            return other != null && other.Name == Name && other.Age == Age;
        }
    }
