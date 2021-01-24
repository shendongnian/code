c#
while (!testword.SequenceEqual(word))
{
    while (!validLetterInput) // <-- Need to reset this after first correct validation
    {
        try
        {
            Console.Write("Please enter a letter to guess: ");
            guess = char.Parse(Console.ReadLine().ToLower());
            //Checks if guess is letter or not
            if (((guess >= 'A' && guess <= 'Z') || (guess >= 'a' && guess <= 'z')))
            {
                validLetterInput = true;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    validLetterInput = false; // <--- ADD THIS HERE
After the first letter is accepted as valid character, it is never reset for the next letter. Once you exit the while loop where you are checking for valid input, reset the validLetterInput to false
