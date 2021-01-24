    int foundAtIndex = -1;
    for (int l = 0; l < localPets4.Length; l++) 
    { 
        if (userInput2 == localPets4[l])
        { 
            foundAtIndex = l;
        }
    }
    if (foundAtIndex != -1)
    {
            Console.WriteLine("{0} makes the sound {1}", localPets4[foundAtIndex ],localSounds2[foundAtIndex ]);
            Console.WriteLine(); 
    }
    else 
    {
        Console.WriteLine($"Sorry, {userInput2} isn't in our list of animals");
        Console.WriteLine(); 
    }
