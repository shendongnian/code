    class Player
    {
        private static readonly Random Random = new Random();
        public string Name { get; set; }
        public bool IsComputer { get; set; }
        public int PlayTurn(int chipsRemaining)
        {
            var maxToTake = Math.Min(4, chipsRemaining);
            var chipsTaken = IsComputer
                ? Random.Next(maxToTake) + 1
                : Program.GetIntFromUser(
                    $"There are {chipsRemaining} chips remaining. " +
                    $"Enter the number to take (1 - {maxToTake}): ",
                    x => x > 0 && x <= maxToTake);
            if (IsComputer) Console.WriteLine($"Computer takes {chipsTaken} chips");
            return chipsRemaining - chipsTaken;
        }
    }
