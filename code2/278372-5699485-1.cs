    Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator();
    
    using (enumerator)
    {
        while (enumerator.MoveNext())
        {
            //Do something with enumerator.Current.Key
            //Do something with enumerator.Current.Value
        }
    }
