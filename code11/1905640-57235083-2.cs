    [Serializable()]
    public class Member
    {
        public Member() { }
        public Member(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => $"{this.FirstName} {this.LastName}";
    }
