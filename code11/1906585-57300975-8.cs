	class ApiRecord
	{
		public ApiRecord(string[] s)
		{
			apiField1 = new ApiField1(s[0], s[5]);
			apiField2 = s[1];
			apiField5 = s[2];
		}
		public ApiField1 apiField1 { get; }
		public string apiField2 { get; }
		public string apiField5 { get; }
	}
