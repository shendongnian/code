    public static class InteractorUtils
    {
    	public static T ExecuteQuery(this IDBInteractor<T> interactor, string myQuery)
    	{
       		return interactor.ExecuteDSQuery(myQuery);
    	}
    }
