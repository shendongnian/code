	ListItemCollection items = lista.GetItems(query);
	var fields = list.Fields;
	context.Load(items);
	context.Load(fields);
	context.ExecuteQuery();
	foreach (ListItem listItem in items)
	{
		foreach (Field field in fields)
		{
			 Console.WriteLine(item[field.InternalName]);
		}
	}
