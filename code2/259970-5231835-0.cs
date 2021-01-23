    public void Add(YourIdType key,TzThing thing )
    {
       if(dictionary.ContainsKey(key))
       {
          dictionary[key].Add(thing);
       }
       else
       {
          dictionary.Add(key,new List<TzThing> {thing});
       }
    }
