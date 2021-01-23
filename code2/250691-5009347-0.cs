    // or IEnumerator<KeyValuePair<string, cAsso>>
    using(var iterdico = mDico.GetEnumerator())
    {
       while (iterdico.MoveNext())
       {
           // var = KeyValuePair<string, cAsso>
           var kvp = iterdico.Current;
           // var = cAsso
           var value = kvp.Value;
           ...
       }
    }
