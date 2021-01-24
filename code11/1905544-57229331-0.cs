`
string input = "O:2275000 BF:3060000 D:3260000";
string[] parts = input.Split(' ');
string[] numbers = parts
    .Select(s => s.Split(':')[1])
    .ToArray();
for(int i = 0; i < numbers.Length; i++)
{
	Console.WriteLine("{0}.{1}", i+1, numbers[i]);
}
`
