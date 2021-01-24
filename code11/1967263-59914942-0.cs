public static class ClassIG<TLibrary>
{
	public static Guid UpsertRequest(
	  IInput inputg,
	  MasterSection masterSection,
	  RequestInput requestInputs,
	  APIDbContext dbContext
	  TLibrary libraryg)
	{
		Guid id = Guid.NewGuid();
        // You will need to implement this method so that the correct library is 
        // added to the correct collection.
		AddLibrary<TLibrary>(libraryg);
		dbContext.SaveChanges();
		var request = RequestHelper.CreateRequest(masterSection, libraryg.Id, requestInputs, dbContext);
		dbContext.Requests.Add(request);
		dbContext.SaveChanges();
		return request.Id;
	}
}
With the limited information that I have, this is what I came up with, you should consider your particular case.
