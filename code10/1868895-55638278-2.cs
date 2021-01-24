    public abstract class ConsoleReadType<T, ConcreteReaderT> where T: struct where ConcreteReaderT: ConsoleReadType<T, ConcreteReaderT>, new()
    {
        public abstract T Read();
        public abstract T Read(T? min, T? max);
        public static T ReadUntilCorrect(string message = "") 
        {
            ConcreteReaderT reader = new ConcreteReaderT();
            while (true)
            {
                try
                {
                    return reader.Read();
                }
                catch (ConsoleInputException)
                {
                    if (!string.IsNullOrEmpty(message))
                        Console.Error.WriteLine(message);
                }
            }
        }
    }
    // Use the concrete class as its own type parameter so that
    // the base class can use the concrete class without knowing it 
    // beforehand
    public class ConsoleReadDouble : ConsoleReadType<double, ConsoleReadDouble>
    {
        public override double Read()
        {
            if (!double.TryParse(Console.ReadLine().Replace(".", ","), out double ret))
            {
                throw new ConsoleInputException();
            }
            return ret;
        }
        public override double Read(double? min, double? max)
        {
            if (!double.TryParse(Console.ReadLine().Replace(".", ","), out double ret))
            {
                throw new ConsoleInputException("invalid input format");
            }
            if (min.HasValue && ret < min || max.HasValue && ret > max)
            {
                throw new ConsoleInputException("input value should be between: " + min + " and " + max);
            }
            return ret;
        }
    }
