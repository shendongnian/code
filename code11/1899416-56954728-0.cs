	public class EmailManyDto
	{
		public string Recipient 
		{
			get
			{
				return Recipients.FirstOrDefault();
			}
			set
			{
				Recipients.Insert(0, value);
			}
		}
		public List<string> Recipients { get; set; } = new List<string>();
		public string Content { get; set; }
		public string Subject { get; set; }
	}
	
