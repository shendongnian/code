    public interface IThing
    {
        IThing2[] Thing2s();
        string DoSomething();
    }
    
    public class Thing : IThing
    {
        private readonly IThing2[] _thing2s = new IThing2[1] { new Thing2() };
        public IThing2[] Thing2s() => _thing2s;
        public string DoSomething()
        {
            return "MyText";
        }
    }
    public interface IThing2
    {
    }
    public class Thing2 : IThing2
    {
    }
