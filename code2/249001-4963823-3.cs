    AttributeMappingSource mappping = new System.Data.Linq.Mapping.AttributeMappingSource();
    var model = mappping.GetModel(typeof(MyDataContext));
  
    MetaFunction function = model.GetFunction(typeof(MyDataContext).GetMethod("MyStoredProc"));
      
    foreach (var resultTypes in function.ResultRowTypes)
    {
        foreach (var column in resultTypes.DataMembers)
        Console.WriteLine(column.Name);
           
    }
