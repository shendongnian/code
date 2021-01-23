    var stream1Enumerator = stream1.GetEnumerator();
    var stream2Enumerator = stream2.GetEnumerator();
    var currentGroupId = -1; // Initial value
    // i.e. Until stream1Enumerator runs out of 
    while (stream1Enumerator.MoveNext())
    {
       // Now you can iterate the collections independently
       if (stream1Enumerator.Current.Id != currentGroupId)
       {
           stream2Enumerator.MoveNext();
           currentGroupId = stream2Enumerator.Current.Id;
       }
       // Do something with stream1Enumerator.Current and stream2Enumerator.Current
    }
