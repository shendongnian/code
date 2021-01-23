    var outputNeeded = new Dictionary<int, Collection<User>>();
    foreach(var kvp in list)
    {
       Collection<User> targetBucket;
       
       if(!outputNeeded.TryGetValue(kvp.key, out targetBucket) 
       {
           // bucket doesn't exist, add a new bucket containing the user
           outputNeeded.Add(kvp.Key, new Collection<User> { kvp.Value });
       }
       else 
       {   // bucket already exists, append user to it.
           targetBucket.Add(kvp.Value);
       }
    }
