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
**EDIT**  
Using only for loop
c#
string substringToSearch = inputKey.Length >= 3 ? inputKey.Substring(0, 3) : inputKey;
for(int i; i < dictionaryObject.Keys.Count; i++)
{       
    if( dictionaryObject.ElementAt(i).Key.StartsWith(substringToSearch) )
    {
        // key matched with inputKey
        // below is key
        string keyStr = dictionaryObject.ElementAt(i).Key;
    }
}
