    public class SomeClass<T> where T : IDBInteractor <T>, new()
    {
    	public T ExecuteQuery(string myQuery)
    	{
    	   return new T().ExecuteDSQuery(myQuery);
    	}
    }
