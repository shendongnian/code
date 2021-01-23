    public interface IGetValue
    {
        object Value
        {
            get;
        }
    }
    
    public interface IGetValue<out T>
    {
        T Value
        {
            get;
        }
    }
    
    public class GetValue<T> : IGetValue<T>, IGetValue
    {
        public GetValue(T value)
        {
            _value = value;
        }
    
        private T _value;
        public T Value
        {
            get { return _value; }
        }
    
        object IGetValue.Value
        {
            get { return _value; }
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            IGetValue<string> GetString = new GetValue<string>("Hello");
            IGetValue<int> GetInt = new GetValue<int>(21);
    
            if (GetString is IGetValue)
            {
                Console.WriteLine("GetValue<string> is an IGetValue");
            }
            else
            {
                Console.WriteLine("GetValue<string> is not an IGetValue");
            }
    
            if (GetInt is IGetValue)
            {
                Console.WriteLine("GetValue<int> is an IGetValue");
            }
            else
            {
                Console.WriteLine("GetValue<int> is not an IGetValue");
            }
    
            Console.ReadKey();
        }
    }
