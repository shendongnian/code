    static void Main()
    {
        Song start = new Song("1");
        Song curr  = start;
        Song halfway = null;
        for (int i = 2; i < 100; ++i)
        {
            curr.NextSong = new Song(i.ToString());
            curr = curr.NextSong;
            if (i == 50)
                halfway = curr;
        }
        curr.NextSong = halfway;
        Console.WriteLine(start.IsRepeatingPlaylist());
    }
