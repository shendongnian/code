// Declare price as a decimal.
decimal price = 29.95m;
You can also specify cultures using:
// For German culture.
Console.WriteLine(price.ToString("C", new CultureInfo("en-DE")));
// Output
// 29,95 €
// For British culture.
Console.WriteLine(price.ToString("C", new CultureInfo("en-GB")));
// Ouput
// £29.95
**Edit:** Just saw your update, glad it was just a display issue. 
