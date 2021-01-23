    public class Foo
    {
        private IObjFactory _provider;
        public Foo(IObjFactory _provider)
        {
            this._provider = provider;
        }
        public void DoSomething()
        {
            var myObj = _provider.GetObj();
            myObj.DoSomething();
            myObj.DoSomethingElse();
        }
    }
    public interface IObjFactory
    {
        ISomeType GetObj();
    }
