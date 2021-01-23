    public interface INode
    {
        List<INode> Nodes { get; set; }
    }
    public class Person : INode
    {
        public List<INode> Nodes { get; set; }
        private string _name;
        public Person(string name)
        {
            _name = name;
        }
    }
    public class Computer : INode
    {
        public List<INode> Nodes { get; set; }
        private int _number;
        public Computer(int number)
        {
            _number = number;
        }
    }
