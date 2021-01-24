    bool isValid;
    do
    {
         Console.Write("\n\tGuess a number between 1 and 20: ");
         isValid = Int32.TryParse(Console.ReadLine(), out myNum);
         if(!isValid)
         {
             Console.WriteLine("\n\tInvalid input detected. Please try again.");
         }
    } while(!isValid)
