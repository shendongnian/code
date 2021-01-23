    protected override void OnInvoke(ScheduledTask task)
    {
        if (task is PeriodicTask)
        {
            SharedClass.makeTheRequest(this.NotifyComplete);
        }
    }
    public class SharedClass
    {
        public static void makeTheRequest(Action callback)
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri("http://foo.bar"));
            request.BeginGetResponse(r => callback.Invoke(), request);
        }
    }
