    internal class ForExample
    {
        void DoItLikeThis()
        {
            var provider = new StringMethodProvider();
            provider.Register("doSomethingAndGetGuid", args => DoSomeActionWithStringToGetGuid((string)args[0]));
            provider.Register("thenUseItForSomething", args => DoSomeActionWithAGuid((Guid)args[0],(bool)args[1]));
            Guid guid = provider.Intercept<Guid>("doSomethingAndGetGuid", "I don't matter except if I am null");
            bool isEmpty = guid == default(Guid);
            provider.Intercept("thenUseItForSomething", guid, isEmpty);
        }
        private void DoSomeActionWithAGuid(Guid id, bool isEmpty)
        {
            // code
        }
        private Guid DoSomeActionWithStringToGetGuid(string arg1)
        {
            if(arg1 == null)
            {
                return default(Guid);
            }
            return Guid.NewGuid();
        }
    }
    public class StringMethodProvider
    {
        private readonly Dictionary<string, Func<object[], object>> _dictionary = new Dictionary<string, Func<object[], object>>();
        public void Register<T>(string command, Func<object[],T> function)
        {
            _dictionary.Add(command, args => function(args));
        }
        public void Register(string command, Action<object[]> function)
        {
            _dictionary.Add(command, args =>
                                         {
                                             function.Invoke(args);
                                             return null;
                                         } );
        }
        public T Intercept<T>(string command, params object[] args)
        {
            return (T)_dictionary[command].Invoke(args);
        }
        public void Intercept(string command, params object[] args)
        {
            _dictionary[command].Invoke(args);
        }
    }
