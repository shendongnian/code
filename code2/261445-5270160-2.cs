    public static IEnumerable<HttpPostedFile> ToEnumerable(this HttpFileCollection collection)
    {
    	foreach (var item in collection.AllKeys)
    	{
    		yield return collection[item];
    	}
    }
