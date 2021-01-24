       KeyInfo = Console.ReadKey(true);
            while (KeyInfo.Key != ConsoleKey.Escape)
            {
                animal = GwtAnimal(KeyInfo);
                if (KeyInfo.Key == ConsoleKey.C)
                {
                    myCat.AnimalSound();
                }
                else if (KeyInfo.Key == ConsoleKey.D)
                {
                    myDog.AnimalSound();
                }
                KeyInfo = Console.ReadKey(true);
            }
