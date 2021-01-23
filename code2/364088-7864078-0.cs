    static void Main()
    {
        var command1 = new PersistenceCommand(new MyIntBO());
        var command2 = new PersistenceCommand(new MyGuidBO());
        var command3 = new PersistenceCommand(new PersistentBO());
    
        Console.WriteLine(command1.ToString());
        Console.WriteLine(command2.ToString());
        Console.WriteLine(command3.ToString());
        Console.ReadLine();
    }
    
    public class PersistenceCommand
    {
        public PersistenceCommand(PersistentBO businessObject)
        {
            _businessObject = businessObject;
        }
    
        public override string ToString()
        {
            string result = _businessObject.GetType().Name;
    
            var keyed = _businessObject as IPrimaryKeyed;
    
            if (keyed != null)
            {
                result += " " + keyed.Id.ToString();
            }
    
            return result;
        }
    
        private readonly PersistentBO _businessObject;
    }
    
    public interface IPrimaryKeyed
    {
        object Id { get; }
    }
    
    public class PersistentBO { }
    
    public class MyIntBO : PersistentBO, IPrimaryKeyed
    {
        public object Id { get { return 1008; } }
    }
    
    public class MyGuidBO : PersistentBO, IPrimaryKeyed
    {
        public object Id { get { return new Guid("6135d49b-81bb-43d4-9b74-dd84c2d3cc29"); } }
    }
