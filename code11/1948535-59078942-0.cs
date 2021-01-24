c#
var CharactersToRemove { get; set; } = " ,.;:!?";
var processedInput = Regex.Replace(input.ToLower(), $"[{CharactersToRemove}]", string.Empty);
Note, that here I used `input.ToLower()` to convert the input to a lowercase string. This will make the palindrome tests case-insensitive. Should you need case-sensitive palindrome tests, just remove the `.ToLower()` part.
There is no need to reverse the input string to check if it is a palindrome. You can check this within one `for` loop as follows:
c#
bool CheckForBeingaAPalindrome(string input)
{
    if (string.IsNullOrEmpty(input))
		return false;
	var frontIndex = 0;
	var tailIndex = input.Length - 1;
	for (; frontIndex < tailIndex;)
	{
		if (input[frontIndex] != input[tailIndex])
            return false;
		++frontIndex;
		--tailIndex;
	}
	return true;
}
Note, that in this case you only iterate over the elements of the input string once. This approach will give you al least 4 times better performance than the one you used.
Below, you can find a complete minimal working solution to your problem.
c#
using System.Text.RegularExpressions;
using static System.Console;
namespace Assignment
{
    public static class PalindromeFinder
    {
        public static string CharactersToRemove { get; set; } = " ,.;:!?";
        public static bool IsPalindrome(string input)
        {
            var processedInput = RemoveUnnecessaryCharacters(input);
            return CheckForBeingAPalindrome(processedInput);
        }
        private static string RemoveUnnecessaryCharacters(string input)
        {
            return Regex.Replace(input.ToLower(), $"[{CharactersToRemove}]", string.Empty);
        }
        private static bool CheckForBeingAPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            var frontIndex = 0;
            var tailIndex = input.Length - 1;
            for (; frontIndex < tailIndex;)
            {
                if (input[frontIndex] != input[tailIndex])
                    return false;
                ++frontIndex;
                --tailIndex;
            }
            return true;
        }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            ContinuouslyCheckUserInputForBeingAPalindrome();
        }
        private static void ContinuouslyCheckUserInputForBeingAPalindrome()
        {
            while (FetchUserInputFromConsole() is string input
                   && !PalindromeFinder.IsPalindrome(input))
                WriteLine("It is not palindrome");
            WriteLine("It is palindrome");
            ReadKey();
        }
        private static string FetchUserInputFromConsole()
        {
            Write("Enter a palindrome: ");
            return ReadLine();
        }
    }
}
