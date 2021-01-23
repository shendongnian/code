     private Action<TListPropertyContainer, TDataValue> CreateListPropertySetter<TListPropertyContainer, TDataValue>(string listName)
     {
           var propertyInfo = typeof(TListPropertyContainer).GetProperty(listName);
           return (container,value) => {
                var list = (IList<TDataValue>)propertyInfo.GetValue(container,null);
                list.AddCSV(list);
           };
      }
