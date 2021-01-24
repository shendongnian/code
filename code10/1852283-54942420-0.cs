    public abstract class RequestBase
    {
    }
    public class ReqThing1 : RequestBase
    {
    }
    public class ReqThing2 : RequestBase
    {
    }
    public interface IThing<T> where T : RequestBase
    {
        string Process(T input);
    }
    public class Thing1 : IThing<ReqThing1>
    {
        public string Process(ReqThing1 input)
        {
            throw new System.NotImplementedException();
        }
    }
    public class Thing2 : IThing<ReqThing2>
    {
        public string Process(ReqThing2 input)
        {
            throw new System.NotImplementedException();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var thing1 = new Thing1();
            var thing2 = new Thing2();
        }
    }
