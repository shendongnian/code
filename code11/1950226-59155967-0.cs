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
You can go event further and omit your `tag` variable if you use the input as loop condition:
var input = "";
var numbers = new List<int>();
while((input = Console.ReadLine()) != "ok")
{
    numbers.Add(int.Parse(input));
}
