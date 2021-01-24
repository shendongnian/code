    int russiaCount = 0;
    int germanyCount = 0;
    string[] replayslol = System.IO.Directory.GetFiles(@"./replays", "*.wotreplay");
    foreach (string file in replayslol)
    {
        if (file.Contains("_ussr-")) {
            russiaCount++;
        }
        if (file.Contains("_germany-")) {
            germanyCount++;
        }
    }
    Console.WriteLine("You've played Russian vehicles {0} times and German vehicles {1} times!", russiaCount, germanyCount);
