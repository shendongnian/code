    void p_PingCompleted(object sender, PingCompletedEventArgs e)
    {
        var game = (Game)e.UserState;
        if (e.Reply.Status != IPStatus.Success)
        {
            Console.WriteLine(
                "  Could not reach {0} ({1}), removing this server...",
                game.IP,
                e.Reply.Status);
            lock (GameList)
            {
                GameList.Remove(game);
            }
        }
        else
        {
            Console.WriteLine(
                "Ping reply from: {0} in {1} ms",
                e.Reply.Address,
                e.Reply.RoundtripTime);
            if (e.Reply.RoundtripTime == 0 ||
                e.Reply.RoundtripTime >= 2500)
            {
                Console.WriteLine("  Ping too high, removing this server...");
                lock (GameList)
                {
                    GameList.Remove(game);
                }
            }
        }
    }
