c#
string[] keyArray = new string[]{ "3930000", "4200000" , "5200000"};
string substringToSearch ;
foreach(string inputKey in keyArray)
{
    substringToSearch = inputKey.Length >= 3 ? inputKey.Substring(0, 3) : inputKey;
    if(dictionaryObject.Keys.Any(x => x.StartsWith(substringToSearch)))
    {
        // below is the key matched with inputKey
        dictionaryObject.Where(x => x.Key.StartsWith(substringToSearch)).First().Value;
    }
}
