    public void startPool(Channel channel)
    {
        polls.Add(channel, new Poll(question, tempdict));
        polls[channel].Elapsed += poll_Elapsed;
        polls[channel].Start();
    }
    static void poll_Elapsed(object sender, ElapsedEventArgs e)
    {
        //sender is now a Poll object
        var poll = sender as Poll;
        // Now you can do poll.pollTimer.Stop()
        // Or better yet, add a Stop method to the Poll class and call poll.Stop()
    }
