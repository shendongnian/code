    public class DatabaseException : Exception {}
    public class MySpecificException : DatabaseException {}
    public class YetAnotherDBSpecificException : DatabaseException {}
    try
    {
       // insert data.
    }
    catch(DatabaseException dbEx)
    {
       // A database exception occured.
       Console.Log(dbEx.Message);
    }
    catch(Exception other)
    {
       // Non db exception occured.
       Console.Log(other.Message);
    }
