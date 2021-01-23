	if(list.Count>0)
	{
		var firstItem = list[0];
		var type = response.GetType();
		PropertyInfo nameInfo = type.GetProperty("Name");
		nameInfo.GetValue(firstItem, null);					//returns list[0].Name
		nameInfo.SetValue(firstItem, "somevalue", null); ;	//sets list[0].Name to "somevalue"
		PropertyInfo someInfo = type.GetProperty("SomeProperty");
		someInfo.GetValue(firstItem, null);					//returns list[0].SomeProperty
		someInfo.SetValue(firstItem, "somevalue", null); ;	//sets list[0].SomeProperty to "somevalue"
	}
