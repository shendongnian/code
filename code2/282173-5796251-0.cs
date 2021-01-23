    // Create a List<> of unknown type at compile time.
    Type customList = typeof(List<>).MakeGenericType(tempType);
    IList objectList = (IList)Activator.CreateInstance(customList);
    // Copy items from a PropertyInfo list to the object just created
    object o = objectThatContainsListToCopyFrom;
    PropertyInfo p = o.GetType().GetProperty("PropertyName");
    IEnumerable copyFrom = p.GetValue(o, null);
    foreach(object item in copyFrom) objectList.Add(item); // Will throw exceptions if the types don't match.
    
    // Iterate and access the items of "objectList"
    // (objectList declared above as non-generic IEnumerable)
    foreach(object item in objectList) { Debug.WriteLine(item.ToString()); }
