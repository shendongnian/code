   	public class UserOptionsMsSql
	{
		[Column("Set Option")]
		public string SetOption { get; set; }
		public string Value { get; set; }
	}
    var resultsList = 
    service.GetDataContext().Database.SqlQuery<UserOptionsMsSql>
    ("DBCC USEROPTIONS;").ToList();
	var resultLevel =  resultsList[11] == null ? "unknown":resultsList[11].Value ;
