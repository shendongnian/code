    public interface IWorkPerson
    {
        string FirstName { get; set; }
        string LastName  { get; set; }
        string WorkPhone { get; set; }
    }
    public interface IHomePerson
    {
        string FirstName { get; set; }
        string LastName  { get; set; }
        string HomePhone { get; set; }
    }
    public class Person : IWorkPerson , IHomePerson
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
    }
