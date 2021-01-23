	ActiveDirectorySchema schema = ActiveDirectorySchema.GetCurrentSchema();
	ActiveDirectorySchemaClass person = schema.FindClass("user");
	foreach( ActiveDirectorySchemaProperty property in person.GetAllProperties() )
	{
		Console.WriteLine("{0} = {1}", property.CommonName, property.Name);
	}
