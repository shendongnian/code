cs
var input = "Senior Business Developer";
var parts = input.Split(" ");
for (int i = 0; i < parts.Length; i++)
{
	var output = parts.Skip(i);
	Console.WriteLine(string.Join(' ', output));
}
`Split` string into the parts using space as separator and skip the last item at every iteration
