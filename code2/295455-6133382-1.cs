    // Demo values, use existing code somewhere here.
    var directory = FSDirectory.Open(new DirectoryInfo("index"));
    var reader = IndexReader.Open(directory, readOnly: true);
    var documentId = 1337;
    // Grab all subreaders.
    var subReaders = new List<IndexReader>();
    ReaderUtil.GatherSubReaders(subReaders, reader);
    // Loop through all subreaders. While subReaderId is higher than the
    // maximum document id in the subreader, go to next.
    var subReaderId = documentId;
    var subReader = subReaders.First(sub => {
        if (sub.MaxDoc() < subReaderId) {
            subReaderId -= sub.MaxDoc();
            return false;
        }
        return true;
    });
    var values = FieldCache_Fields.DEFAULT.GetInts(subReader, "id");
    var value = values[subReaderId];
