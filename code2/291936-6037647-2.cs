    var sources = BlockingCollection<SourceData>();
    var producerOptions = new ParallelOptions { MaxDegreeOfParallelism = 5 };
    var consumerOptions = new ParallelOptions { MaxDegreeOfParallelism = -1 };
    var producers = Task.Factory.CreateNew(
        () => {
            Parallel.ForEach(MyLGenericList, producerOptions, 
                myObject => {
                    myObject.DoLoad()
                    sources.Add(myObject)
                });
            sources.CompleteAdding();
        });
    Parallel.ForEach(sources.GetConsumingPartitioner(), consumerOptions,
        myObject => {
            myObject.CreateImage();
            myObject.Dispose();
        });
