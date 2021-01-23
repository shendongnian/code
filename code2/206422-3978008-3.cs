    var outputNeeded = new Dictionary<int, Collection<User>>();
    foreach(var kvp in list)
    {
       Collection<User> userBucketForId;
       
       if(!outputNeeded.TryGetValue(kvp.Key, out userBucketForId)) 
       {
           // bucket doesn't exist, create a new bucket for the Id, containing the user
           outputNeeded.Add(kvp.Key, new Collection<User> { kvp.Value });
       }
       else 
       {   // bucket already exists, append user to it.
           userBucketForId.Add(kvp.Value);
       }
    }
