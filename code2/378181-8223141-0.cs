    class Program
    {
        static void Main(string[] args)
        {
            IList<IMyType> lst = new List<IMyType>();
            lst.Add(new MyType1());
            lst.Add(new MyType2());
            lst.Add(new MyType3());
            foreach (var lstItem in lst)
            {
                Console.WriteLine(lstItem.GetType());
            }
        }
    }
    public interface IMyType { }
    public class MyType1 : IMyType { }
    public class MyType2 : IMyType { }
    public class MyType3 : IMyType { }
