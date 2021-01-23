    var sources = BlockingCollection<SourceData>();
    var producer = Task.Factory.CreateNew(
        () => {
            foreach (var item in MyGenericList) {
                var data = webservice.FetchData(item);
                sources.Add(data)
            }
            sources.CompleteAdding();
        }
    )
    Parallel.ForEach(sources.GetConsumingPartitioner(),
                     data => {
                         imageCreator.CreateImage(data);
                     });
