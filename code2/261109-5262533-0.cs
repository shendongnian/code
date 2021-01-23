    DateTime timeOfNextOperation = DateTime.Now.AddMinutes(1);
    Console.WriteLine(timeOfNextOperation);
    while (true)
    {
        if (DateTime.Now >= timeOfNextOperation)
        {
            Console.WriteLine("Do Stuff Here");
            timeOfNextOperation = DateTime.Now.AddMinutes(1);
        }
        Thread.Sleep(1000);
    }
