    public class Group
    {
    public Group()
    {
        Members = new List<Member>();
    }
    public IEnumerable<Member> Members { get; set; }
    }
    public class Member
    {
    public Member()
    {
        Properties = new Dictionary<string, string>();
    }
    public string Name { get; set; }
    IDictionary<string, string> Properties { get; set; }
    }
