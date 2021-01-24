	var items = lista.GetItems(query);
	var fields = list.Fields;
    var fieldsToIgnore = new[] { "ContentType", "Attachments" };
	context.Load(items);
	context.Load(fields);
	context.ExecuteQuery();
	foreach (ListItem listItem in items)
	{
		foreach (Field field in fields)
		{
             if (!fieldsToIgnore.Contains(fld.InternalName))
			     Console.WriteLine(item[field.InternalName]);
		}
	}
