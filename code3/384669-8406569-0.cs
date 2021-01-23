	public class EntityValueType
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		// Change this to the correct type, I was unable to determine the type from your code. 
		public string EntityStatus { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
	}
	public class AuditActionType: EntityValueType
	{
	}
	
	private List<T> BuildTypes<T>(XDocument xDocument) where T: EntityValueType, new()
	{
		return (from ty in xDocument.Descendants("RECORD")
			select new T
				{
					Id = GenerateGuid(),
					Name = ty.Element("Name").Value,
					EntityStatus = _activeEntityStatus,
					DateCreated = DateTime.Now,
					DateModified = DateTime.Now
				}).ToList();
	} 
