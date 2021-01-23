    public interface IResponse
    {
        string ResponseCode { get; }
    }
    public sealed class Response : IResponse
    {
        private readonly string responseCode;
        private Response(string responseCode)
        {
            this.responseCode = responseCode;
        }
        public string ResponseCode { get { return this.responseCode; } }
        public static IResponse Create(string responseCode)
        {
            return new Response(responseCode);
        }
    }
    public sealed class DoItCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IResponse response;
        public DoItCompletedEventArgs(
            Exception error,
            bool canceled,
            object userState,
            IResponse response) : base(error, canceled, userState)
        {
            this.response = response;
        }
        public IResponse Response { get { return this.response; } }
    }
    public interface IDoStuff
    {
        event EventHandler<DoItCompletedEventArgs> DoItCompleted;
        bool CanProcessAsynchronously { get; }
        IResponse DoIt(string[] args);
        void DoItAsync(string[] args);
    }
    public sealed class DoStuff : IDoStuff
    {
        private delegate IResponse DoItDelegate(string[] args);
        public event EventHandler<DoItCompletedEventArgs> DoItCompleted;
        public bool CanProcessAsynchronously { get { return true; } }
        private DoStuff()
        {
        }
        public static IDoStuff Create()
        {
            return new DoStuff();
        }
        public IResponse DoIt(string[] args)
        {
            return Response.Create(args.Aggregate(string.Empty, (current, arg) => current + arg));
        }
        public void DoItAsync(string[] args)
        {
            DoItDelegate doIt = this.DoIt;
            doIt.BeginInvoke(args, this.DoDoItCompleted, doIt);
        }
        private void DoDoItCompleted(IAsyncResult result)
        {
            if (result == null)
            {
                return;
            }
            var doIt = result.AsyncState as DoItDelegate;
            if (doIt == null)
            {
                return;
            }
            var response = doIt.EndInvoke(result);
            var doItCompleted = this.DoItCompleted;
            if (doItCompleted != null)
            {
                doItCompleted(this, new DoItCompletedEventArgs(null, false, null, response));
            }
        }
    }
    internal static class Program
    {
        private static void Main()
        {
            var doStuff = DoStuff.Create();
            if (doStuff.CanProcessAsynchronously)
            {
                var response = doStuff.DoIt(new[] { "stuff 1 ", "more stuff 1" });
                Console.WriteLine(response.ResponseCode);
            }
            else
            {
                doStuff.DoItCompleted += DoItCompleted;
                doStuff.DoItAsync(new[] { "stuff 2 ", "more stuff 2" });
            }
            Console.ReadLine();
        }
        private static void DoItCompleted(object sender, DoItCompletedEventArgs e)
        {
            Console.WriteLine(e.Response.ResponseCode);
        }
    }
