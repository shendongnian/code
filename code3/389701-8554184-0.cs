    void Main()
    {
        System.Threading.Timer timer = new System.Threading.Timer(Callback, channel, 0, 10 * 60 * 1000);
    }
    void Callback(object state)
    {
        ChannelAdvertise(this, (Channel)state);
    }
