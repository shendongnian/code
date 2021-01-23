    public interface IName
    {
        dynamic name { get; set; }
    }
    public class Person: IName
    {
        private string _name;
        public dynamic name { get { return _name; } set { _name = value;} }
    }
