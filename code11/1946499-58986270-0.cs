    var sw = Stopwatch();
    foreach(Hyland.Unity.Document d in dl)
    {
        // note: the stop is here intentionally to see how long 
        // it takes to materialize each item
        sw.Stop();
        // if this is taking a long time, the bottleneck is (likely) 
        // in whatever the 3rd party .dll is doing
        items[counter] = new OnBaseSearchDocument() { DocumentId = d.ID, Name = d.Name, DocumentType = d.DocumentType.Name, DocDate = d.DocumentDate.Ticks, DocReviseDate = d.LatestRevision.Date.Ticks, DocStoreDate = d.DateStored.Ticks };
        counter++;
        sw.Start();
     }
