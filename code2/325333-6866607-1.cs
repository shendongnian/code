    int rolls = Console.ReadLine();
    int total = 0; 
    Random randGen = new Random(System.DateTime.Now.Millisecond);
    for(int i =0; i<rolls; i++)
    {
    int oneRoll = randGen.Next(1,7) + randGen.Next(1, 7);
    Console.WriteLine("Rolled " + oneRoll);
    total += oneRoll;
    }
    Console.WriteLine("Total " + total);
