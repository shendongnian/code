c#
public object CascadeInitializer(Type type)     
{
	var newObj = Activator.CreateInstance(type); // create new instance of your target class
	Func<PropertyInfo,bool> query = q
		=> q.PropertyType.IsClass &&            // Check if property is a class
		   q.CanWrite && 						// Check if property is not readOnly
		   q.PropertyType != typeof(string);    // Check if property is not string
	
	foreach (var el in type.GetProperties().Where(query))
	{
		// create new instance of el cascade
		var elInstance = CascadeInitializer(el.PropertyType);
		el.SetValue(newObj, elInstance);
	}
	return newObj;
}
 
usage 
c#
var x = CascadeInitializer(typeof(Envelope));
