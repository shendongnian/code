    foreach var property in Thing.Properties
    {
       IEnumerable<IGrouping<string, thing>> thingQuery2 = from t in listOfThings    
                                                            group t by t.property;    
        List<thing> listOfThingsFound = new List<thing>();    
        foreach (var thingGroup in thingQuery2)    
        {    
            if (thingGroup.Count() == 1)    
            {    
                foreach (thing thing in thingGroup) // there is only going to be 1    
                    listOfThingsFound.Add(thing);    
            }    
        }
         ...
     }
