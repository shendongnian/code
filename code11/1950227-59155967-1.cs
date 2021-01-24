//[...]
while (tag == true)
{
    Console.Write("Please enter a number or 'ok' to end: ");
    var input = Console.ReadLine();
    if (input.Equals("ok"))
    {
        tag = false;
    }
    else
    {
        int numb = Int32.Parse(input);
        numbers.Add(numb);
    }
}
//[...]
Each time you call `Console.ReadLine`, the user must enter input - because you call it once to compare to "Ok" and once more to parse, the user has to enter a number twice.
You can go even further and omit your `tag` variable if you use the input as loop condition:
var input = "";
var numbers = new List<int>();
while((input = Console.ReadLine()) != "ok")
{
    numbers.Add(int.Parse(input));
}
All of this is without any error handling if the user enters something that's neither "ok" nor a valid integer. For this you should have a look at [`int32.TryParse`](https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netframework-4.8).
