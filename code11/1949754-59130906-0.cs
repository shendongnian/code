var found = new List<char>();
...
if (charArray.Any(c => c == userGuess)) // If any character in the char array equals to the guess
{
    if (found.Any(c => c == userGuess))
    {
        Console.WriteLine($"{userGuess} is already in the word");
    }
    else
    {
        found.Add(userGuess);
    }
}
else 
{
    Console.WriteLine($"{userGuess} is not in the word");
    guesses++;
}
Any by the way is a Linq extension method, which checks if any element of a collection matches the predicate you enter as a parameter. For that you have to use a javascript-like arrow function syntax.
