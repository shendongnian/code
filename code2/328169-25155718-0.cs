    //query the internal name of the "Phone" field
    Field field = list.Fields.GetByInternalNameOrTitle("Phone");
    context.Load(field);
    context.ExecuteQuery();
    //load items
    var items = list.GetItems(new CamlQuery());
    context.Load(items);
    context.ExecuteQuery();
            
    foreach (var item in items)
    {
       //here we use the internal name
       Console.WriteLine("\t field, phone:{0}", item[field.InternalName]);
    }
