	Dictionary<string, String> apidield1 = new Dictionary<string, string>();
	apidield1.Add("subfield1", "value(csvField1)");
	apidield1.Add("subfield2", "value(csvField6)");
	Dictionary<string, Object> apiRecord = new Dictionary<string, object>();
	apiRecord.Add("apiField2", "value(csvField2)");
	apiRecord.Add("apiField5", "value(csvField3)");
	apiRecord.Add("apiField1", apidield1);
	Console.WriteLine(JsonConvert.SerializeObject(apiRecord));
