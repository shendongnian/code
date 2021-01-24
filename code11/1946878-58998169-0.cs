char guess;
bool guessInputSuccess = false;
do 
{ 
    Console.Write("Guess your letter: ");
    char.TryParse(Console.ReadLine().ToLower(), out guess); 
    if (!char.IsLetter(guess))
    { 
        Console.Write("You have not entered a letter from a-z."); 
    }
    else
    { 
        guessInputSuccess = true; 
    } 
} while (!guessInputSuccess);
return guess; 
Alternatively, give `guess` an initial value. *You* know that it's always going to be assigned, so it doesn't really matter what the value is:
    char guess = '\0';
    bool guessInputSuccess = false;
    while (!guessInputSuccess)
    { 
        Console.Write("Guess your letter: ");
        char.TryParse(Console.ReadLine().ToLower(), out guess); 
        if (!char.IsLetter(guess))
        { 
            Console.Write("You have not entered a letter from a-z."); 
        }
        else
        { 
            guessInputSuccess = true; 
        } 
    }
    return guess; 
