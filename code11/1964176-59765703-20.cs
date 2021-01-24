    public Dto AssignValues(List<string> row)
    {
    	var dto = new Dto();
    	var properties = typeof(Dto).GetProperties().Where(x=>x.GetCustomAttributes<DtoDefinitionAttribute>().Any());
    	foreach(var property in properties)
    	{
    		var attribute = property.GetCustomAttribute<DtoDefinitionAttribute>();
    		if(attribute.IsJson)
    		{
    			var jsonData = row[attribute.Order].ToString();
    			var deserializedData = JsonConvert.DeserializeObject(jsonData,attribute.JsonDataType);
    			property.SetValue(dto,deserializedData);
    		}
    		else
    		{
    			property.SetValue(dto,Convert.ChangeType(row[attribute.Order],property.PropertyType));
    		}
    	}
    	return dto;
    }
