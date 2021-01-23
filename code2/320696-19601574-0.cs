    public interface IReadOnly : IWritable
    {
        new int MyValue { get; }
    }
    public interface IWritable
    {
        int MyValue { get; set; }
    }
    public class Implementation : IReadOnly
    {
        public int MyValue { get; private set; }
        int IWritable.MyValue
        {
            set { MyValue = value; }
            get { return MyValue; }
        }
        public static Implementation GetMyImplementation()
        {
            return ImplementationGateway<Implementation>.GetMyImplementation();
        }
    }
    public class ImplementationGateway<TImplementation>
        where TImplementation : class, IWritable, new()
    {
        public static TImplementation GetMyImplementation()
        {
            return new TImplementation
                {
                    MyValue = 1
                };
        }
    }
    public class Program
    {
        public Program()
        {
            Implementation myImplementation = Implementation.GetMyImplementation();
            myImplementation.MyValue = 0;
        }
        
    }
