static string Format(decimal x)
{
    return x.ToString("$#,0.00", System.Globalization.CultureInfo.InvariantCulture);
}
//Usage:
string currencyFormatedNumber = Format(-41023.43M); //returns -$41,023.43
