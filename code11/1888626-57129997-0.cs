    //Assume at this point in code, we have access to "o"
    //which is type System.Object
    
    Type thingType = thing.GetType();
    Type listType = typeof(List<>);
    Type listOfThingsType = listType.MakeGenericType(thingType);
    
    if (o.GetType() == listOfThingsType)
    {
        //Now I know o contains a list of things
        //...but how do I access them and work with their members?
    
        dynamic oList = o;
        foreach(object thing in oList)
        {
            //operate on thing through reflection
        }
    }
