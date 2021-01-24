    public Dto AssignValues(List<string> row)
    {
    	var dto = new Dto();
    	var properties = typeof(Dto).GetProperties().Where(x=>x.GetCustomAttributes<OrderAttribute>().Any());
    	foreach(var property in properties)
    	{
    		property.SetValue(dto,
                    Convert.ChangeType(row[property.GetCustomAttribute<OrderAttribute>().Order],property.PropertyType));
    	}
    	return dto;
    }
