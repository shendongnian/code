using System.Linq;
And after `Console.WriteLine("The winning number is: " + randomNumber);` replace the for-loop with
if (userGuessNums.Contains(randomNumber))
{
    Console.WriteLine("Congratulations! You won!");
}
else
{
    Console.WriteLine("Sorry, you lose.");
}
