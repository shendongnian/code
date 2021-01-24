    public class DoSomething2:IMyInterface
    {
        public Task DoSomethingAsync()
        {
            doSomethingElse();
            return Task.CompletedTask;
        }
    }
