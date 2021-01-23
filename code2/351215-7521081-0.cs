    string newAge = Console.ReadLine();
    int theAge;
    bool success = Int32.TryParse(newAge, out theAge);
    if(!success)
       Console.WriteLine("Hey! That's not a number!");
    else
       myCharacter.age = theAge;
