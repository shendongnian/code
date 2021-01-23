    var enumerator = collection.GetEnumerator();
    
    while (enumerator.MoveNext())
    {
        if (enumerator.Current.IsPreferred)
        {
            var oldPreferred = enumerator.Current;
            
            if (enumerator.MoveNext())
            {
                oldPreferred.IsPreferred = false;
                enumerator.Current.IsPreferred = true;
            }
    
            break;
        }
    }
