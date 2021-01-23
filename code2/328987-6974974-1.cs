    namespace CTP_Testing
    {
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    public class CustomAsync
    {
        public static CustomAwaitable GetSiteHeadersAsync(string url)
        {
            return new CustomAwaitable(url);
        }
    }
    public class CustomAwaitable
    {
        private readonly Task<string> task;
        private readonly SynchronizationContext ctx;
        public CustomAwaitable(string url)
        {
            ctx = SynchronizationContext.Current;
            this.task = TaskEx.RunEx(
                () =>
                    {
                        var req = (HttpWebRequest)WebRequest.Create(url);
                        req.Method = "HEAD";
                        var resp = (HttpWebResponse)req.GetResponse();
                        return this.FormatHeaders(resp.Headers);
                    });
        }
        public CustomAwaitable GetAwaiter() { return this; }
        public bool IsCompleted { get { return task.IsCompleted; } }
        public void OnCompleted(Action continuation)
        {
            task.ContinueWith(_ => ctx.Post(delegate { continuation(); }, null));
        }
        public string GetResult() { return task.Result; }
        private string FormatHeaders(WebHeaderCollection headers)
        {
            var headerString = headers.Keys.Cast<string>().Select(
                item => string.Format("{0}: {1}", item, headers[item]));
            return string.Join(Environment.NewLine, headerString.ToArray());
        }
    }
}
