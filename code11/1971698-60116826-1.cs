    using System.Linq;
    private HashSet<GameObject> previousEnters = new HashSet<GameObject>();
    ...
    foreach (var result in results.Select(r => r.gameObject))
    {
        Debug.Log(result.name);
        ExecuteEvents.Execute(result, eventDataCurrentPosition, ExecuteEvents.pointerEnterHandler);
        // Store the item so you can later invoke exit on them
        if(!previousEnters.Contains(result)) previousEnters.Add(result);
    }  
    // This uses Linq in order to get only those entries from previousEnters that are not in the results
    var exits = previousEnters.Except(results);
    foreach(var item in exits)
    {
        if(item) ExecuteEvents.Execute(item, eventDataCurrentPosition, ExecuteEvents.pointerExitHandler);
    }
