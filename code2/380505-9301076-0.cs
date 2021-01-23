    interface IRepository {
    IAggregateRoot Get(string rootId);
    //ISubEntityA Get(string rootId); <- this you get from the AR
    //IList<ISubEntityB> Get(string rootId, int offset, int pageSize, out int numPages);
     //for the method above I suggest a different repository and model dedicated for view
    // ISubEntityB Find(string rootId, some specification to select a single ISubEntityB);
    // I can update either the entire aggregate root or an individual sub entity using
    // these methods.
    void Save(IAggregateRoot root); // repository should know if to insert or update, by comparing to the existing instance, use of an OR\M recommended
    //    void Update(string rootId, ISubEntityA a); <- this should be handled by the method above
    //  void Update(string rootId, ISubEntityB b); <- this too
    }
