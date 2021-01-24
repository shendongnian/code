    static void AutoGenrateNumbers()
    {
        var lotto = Enumerable.Range(0, 50).Shuffle(new Random()).Take(7);
	    Console.WriteLine("the new lotto winning numbers are: {0}", string.Join(",", lotto));
    }
