while (true)
{    
    Console.Write("\n\tGuess a number between 1 and 20: ");
    //Checks to see if the input was successfully parsed to a integer also, performs a Trim on the input as to remove any accidental white spaces that a user might have typed in, e.g. "1000 "
    if (int.TryParse(Console.ReadLine().Trim(), out myNum))
    {
        //Checks to see if the parsed number is in the specified range
        if ((myNum > 0) && (myNum < 21))
        {
            break;
        }
        Console.WriteLine("\tThe input number was out of the specified range.");
    }
    else
    {
        Console.WriteLine("\tFailed to parse the input text.");
    }
    //Optional, makes the thread sleep so the user has the time to read the error message.
    Thread.Sleep(1500);
    //Optional, clears the console as to not create duplicates of the error message and the value of Console.Write
    Console.Clear();
}
// Continue here, if (myNum < guessNum) . . .
