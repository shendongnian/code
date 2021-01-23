    public interface IStudent
    {
        public string Name { get; }
        public string City { get; }
        public int Age { get; }
    }
    public class Student : IStudent
    {
        ...
    }
    public class Students : IEnumerable<IStudent>
    {
        ...
    }
