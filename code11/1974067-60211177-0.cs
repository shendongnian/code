string s = "0000-00-00 00:00:01";
if (!DateTime.TryParse(s, out DateTime dt))
{
   // The string could not be parsed to a DateTime.
}
else
{
   // The string was successfully parsed and the variable dt will have the parsed
   // DateTime.
}
Then once you have that, you'll know if you successfully parsed the `string` into a `DateTime` and you can do something other than throw a `FormatException` when it fails.
