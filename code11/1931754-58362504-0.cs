    var dictionary = new Dictionary<string, string>(); //The second string is the type of unit. Which might be wrong.
    
    void AddValue(ClsLinkObject clsLinkObject)
    {
        if(dictionary.ContainsKey(clsLinkObject.clientCode))
        {
            dictionary[clsLinkObject.clientCode] += clsLinkObject.units;
        }
        else
        {
            dictionary.Add(clsLinkObject.clientCode, clsLinkObject.units);
        }
        //You might add to your list as well, if you really want the list here.
    }
