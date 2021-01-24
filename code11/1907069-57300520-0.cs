csharp
//pattern #1
public class DataAccess {
    private readonly DatabaseContext _databaseContext;
    public DataAccess() {
        //initialized in the constructor
        _databaseContext = new DatabaseContext();
    }
}
//pattern #2
public class DataAccess {
    private readonly DatabaseContext _databaseContext;
    public DataAccess(DatabaseContext databaseContext) {
        //The IoC container supplies the instace
        _databaseContext = databaseContext;
    }
}
And the class that uses the DataAccess class will also utilize the same pattern, all the way up in your call chain.
You can read about dependency injection, and in the mean time use pattern #1, and again pay attention to object lifetimes.
