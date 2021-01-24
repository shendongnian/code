if (!DateTime.TryParse($@"{Console.ReadLine()}", out DateTime result))
{
    throw new FormatException("The Date you entered is not a valid date");
}
Console.WriteLine($"{result.ToString("yyyy/MM/dd")}");
