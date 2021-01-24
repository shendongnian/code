// at this point unique numbers have been generated and inputted
int[] numbers = { 1, 2, 3, 4, 5, 6 };
int[] guesses = { 2, 6, 7, 8, 9, 10 };
for (int i = 0; i < guesses.Length; i++)
{
	// The easy way:
	if (numbers.Contains(guesses[i]))
	{
		Console.WriteLine("Hit: " + guesses[i].ToString());
	}
	// the accademic way:
	for (int j = 0; j < numbers.Length; j++)
	{
		if (guesses[i] == numbers[j])
		{
			Console.WriteLine("Hit: " + guesses[i].ToString());
			break; // optional
		}
	}
}
You need to compare every number in guesses with every number in numbers. Therefore you need two nested for loops to check each one.
Alternatively you can use Linq
foreach (int n in numbers.Intersect(guesses))
{
	Console.WriteLine("Hit: " + n.ToString());
}
