    MyCollection<int> collection = new ...
    collection.Find(myPredicate); // <= Will use YOUR Find-method
    
    List<int> baseTypeCollection = collection; // The above instantiated
    baseTypeCollection.Find(myPredicate); // Will use List<T>.Find!
