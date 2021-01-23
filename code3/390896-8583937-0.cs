    var enumerator = collection.GetEnumerator();
    
    while (enumerator.MoveNext())
    {
        if (enumerator.Current.IsPreferred)
        {
            enumerator.Current.IsPreferred = false;
            if (enumerator.MoveNext())
                enumerator.Current.IsPreferred = true;
            
            break;
        }
    }
