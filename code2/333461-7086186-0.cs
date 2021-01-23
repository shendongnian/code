    Proxy proxy = new Proxy();
    raiser.SomeEvent += Proxy.Handler;
    // Then in the subscriber...
    proxy.ProxiedEvent += (whatever)
    // And the proxy class...
    public class Proxy
    {
        public event EventHandler ProxiedEvent;
        public void Handler(object sender, EventArgs e)
        {
            EventHandler proxied = ProxiedEvent;
            if (proxied != null)
            {
                // Or pass on the original sender if you want to
                proxied(this, e);
            }
        }
    }
