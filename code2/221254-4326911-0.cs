    while (true)
    {
        string lineToProcess = myBlockingCollection.Take();
        ProcessLine(lineToProcess);
    }
