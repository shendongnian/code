    class Program
    {
        static void Main(string[] args)
        {
            var methodName = GetMethodName<IMyInteface>(x => new Action<string,string>(x.DoSomething));
            Console.WriteLine(methodName);
        }
        static string GetMethodName<T>(Func<T, Delegate> func) where T : class
        {
            // http://code.google.com/p/moq/
            var moq = new Mock<T>();
            var del = func.Invoke(moq.Object);
            return del.Method.Name;
        }
    }
    public interface IMyInteface
    {
        void DoSomething(string param1, string param2);
    }
