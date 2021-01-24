static void processCraps()
{
    string gameStatus;
    double betAmount;
    double netWinning = 0;
    int point;
    do
    { 
        Console.WriteLine("Enter the amount to bet");
        betAmount = double.Parse(Console.ReadLine());
        var diceRoll = RollDice();
        if (diceRoll == 2 || diceRoll == 3 || diceRoll == 12)
        {
            Console.WriteLine($"You lost {betAmount}");
            netWinning = netWinning - betAmount;
        }
        ... // repeat for the other rolls
    }
}
