    public class Consumer
    {
        private readonly Func<int, HtmlString> doSomething;
        public Consumer(Func<int, HtmlString> doSomething)
        {
            this.doSomething = doSomething;
        }
    }
    // somewhere in the IoC container configuration
    services.AddSingleton<Consumer>(
        s => new Consumer(p => MyHelper.DoSomething(s.GetService<IFileVersionProvider>(), p));
