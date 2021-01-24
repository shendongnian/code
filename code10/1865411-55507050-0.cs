System.Globalization.DateTimeStyles.AdjustToUniversal
Instead of 
System.Globalization.DateTimeStyles.None
So the entire line would be:
if (DateTime.TryParseExact(teststring, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out datePlaceholder))
{do whatever}
