    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is Person))
                return false;
            Person p = (Person)obj;
            return (p.Id == Id && p.Name == Name);
        }
        public override int GetHashCode()
        {
            return String.Format("{0}|{1}", Id, Name).GetHashCode();
        }
    }
