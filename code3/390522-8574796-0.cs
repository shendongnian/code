    public class ExpensiveObject(HttpContext context, ....) : IDisposable
    {
        public Stream OnlyCareAboutThisStream { get; private set; }
    }
...
    Stream myStream = null;
    using (var exObj = new ExpensiveObject(context))
    {
        myStream = exObj.OnlyCareAboutThisStream;
    }
