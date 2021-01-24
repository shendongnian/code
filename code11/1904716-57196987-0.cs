c#
decimal myNumber = -137855027.5123456m;
// two decimals..
string pattern = "#,##0." + "".PadLeft(2, '0');
Console.WriteLine("Pattern: " + pattern);
Console.WriteLine(myNumber.ToString(pattern));
Console.WriteLine();
// 20 decimals..
pattern = "#,##0." + "".PadLeft(20, '0');
Console.WriteLine("Pattern: " + pattern);
Console.WriteLine(myNumber.ToString(pattern));
Console.WriteLine();
// Calculate how much decimals are needed..
int decimals = BitConverter.GetBytes(decimal.GetBits(myNumber)[3])[2];
pattern = "#,##0." + "".PadLeft(decimals, '0');
Console.WriteLine("Pattern: " + pattern);
Console.WriteLine(myNumber.ToString(pattern));
Console.WriteLine();
// If you only want to set the decimals this version would be easier:
Console.WriteLine(myNumber.ToString("{0:N" + decimals + "}"));
