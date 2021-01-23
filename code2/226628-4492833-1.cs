    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        var loadedCollection = (List<MyType>)info.GetValue(
            "myTypeCollection",
            typeof(List<MyType>));
        this.myTypeCollectionLoader = () =>
        {
            this.myTypeCollection.AddRange(loadedCollection);
        };
    }
    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        this.myTypeCollectionLoader();
        this.myTypeCollectionLoader = null;
    }
