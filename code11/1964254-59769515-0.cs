    Dog myDog = new Dog();
    Cat myCat = new Cat();
    Console.WriteLine("--------Press C to call the Cat--------");
    Console.WriteLine("--------Press D to call the Dog--------");
    Console.WriteLine("Press double ESC to close the program");
    ConsoleKeyInfo KeyInfo;
    int counter = 1;
    do
    {
        KeyInfo = Console.ReadKey(true);
        Console.WriteLine("Starting the while loop " + counter);
        counter++;
        if (KeyInfo.Key == ConsoleKey.C)
        {
            myCat.animalSound();
        }
        else if (KeyInfo.Key == ConsoleKey.D)
        {
            myDog.animalSound();
        }
    } while (KeyInfo.Key != ConsoleKey.Escape);
