string consoleInput = Console.ReadLine();
if(Decimal.TryParse(consoleInput, out decimal parsedInput))
{
   string resultString = parsedInput.ToString("N2");
}
else
{
   // handling bad input
}
