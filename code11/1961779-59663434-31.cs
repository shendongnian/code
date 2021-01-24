    static void Main()
    {
        var blocks = GetSampleBlockData();
        var presences = GetSamplePresenceData();
        for(var i = 0; i < blocks.Count; i++)
        {
            var minutesAbsent = blocks[i].MinutesAbsent(presences);
            if (minutesAbsent > 15)
            {
                Console.WriteLine("Error: User was absent for "+
                    $"{minutesAbsent} minutes in block # {i + 1}");
            }
        }
        GetKeyFromUser("\nPress any key to exit...");
    }
