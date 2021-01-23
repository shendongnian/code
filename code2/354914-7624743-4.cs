    public void startPool(Channel channel)
    {
        polls.Add(channel, new Poll(question, tempdict));
        polls[channel].Elapsed += poll_Elapsed;
        polls[channel].Start();
    }
