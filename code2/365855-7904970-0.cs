    using (var dataContext = new DataModel.ModelDataContext())
    {
       var entity = Expression.Parameter(objectType, "model");
       var keyValue = Expression.Property(entity, "Id");
       var pkValue = Expression.Constant(reader.Value);
       var cond = Expression.Equal(keyValue, pkValue);
       var table = dataContext.GetTable(objectType);
    
       var result = table.Where(ent => ((dynamic)ent).SomeField == "SomeValue");
    }
