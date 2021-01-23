    foreach( var pair in dict )
    {
        foreach( var myObj in pari.Value )
        {
            myObj.Id = pair.Key;
        }
    }
    
    return dict.Values.ToList();
