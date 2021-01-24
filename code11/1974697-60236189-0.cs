    private static readonly Random Rnd = new Random();
    // A helper function that returns a list of unique, random numbers from 1 to 49
    private static List<int> GetRandomLotteryTicket()
    {
        var possibilites = Enumerable.Range(1, 49).ToList();
        var ticket = new List<int>();
            
        for (int i = 0; i < 7; i++)
        {
            // Choose a random number from the possibilites
            var randomNumber = possibilites[Rnd.Next(possibilites.Count)];
            ticket.Add(randomNumber);
            // Then remove it so we don't select it a second time
            possibilites.Remove(randomNumber);
        }
        return ticket;
    }
    static void Main()
    {
        // 5 random lottery tickets added as sample data
        var winningTickets = new List<List<int>>
        {
            GetRandomLotteryTicket(),
            GetRandomLotteryTicket(),
            GetRandomLotteryTicket(),
            GetRandomLotteryTicket(),
            GetRandomLotteryTicket()
        };
        // Normally you'd get this from the user, this is just sample data
        var userTicket = GetRandomLotteryTicket();
        Console.WriteLine($"Your numbers are: {string.Join("-", userTicket)}\n");
        foreach (var winningTicket in winningTickets)
        {
            var matchCount = winningTicket.Intersect(userTicket).Count();
            Console.WriteLine($"You matched {matchCount} numbers " + 
                $"with this ticket: {string.Join("-", winningTicket)}");
        }
            
        GetKeyFromUser("\nPress any key to exit...");
    }
