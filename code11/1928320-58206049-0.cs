    while (true) {
        // do some stuff
        Console.WriteLine("Next one? \n1 - Yes \n2 - No");
        string chc2 = Console.ReadLine();
        if (chc2 == "1")
        {
            continue; // means go back to the top of the loop
        }
        if  (chc2 == "2")
        {
            Console.WriteLine("Bye bye");
            Console.ReadKey();                
            break; // means break out of the loop
        }
    }
