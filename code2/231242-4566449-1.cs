    public class Incoming
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public int CategoryType { get; set; }
		public int TemplateID { get; set; }
		public string TemplateName { get; set; }
		public int TemplateXYZ { get; set; }
		public int InstanceID { get; set; }
		public string InstanceName { get; set; }
		public Incoming(int categoryID , string categoryName , int categoryType , int templateId,string templateName ,int templateXYZ , int instanceID , string instanceName    )
		{
			CategoryID =categoryID;
			CategoryName = categoryName; CategoryType = categoryType; TemplateID = templateId;
			TemplateName = templateName; TemplateXYZ = templateXYZ; InstanceID = instanceID; InstanceName = instanceName; 
		}
	}
