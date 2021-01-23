    private readonly HashTable myData;
    [DataMember]
    public HashTable MyData { get { return myData; } }
    public MyType() {
        myData = new HashTable();
    }
