foreach (var name0 in name1)
{
    if (phoneBook.ContainsKey(name0))
    {
        Console.WriteLine(name0 + " = " + phoneBook[name0]);
    }
    else
    {
        Console.WriteLine("Not Found");
    }
}
