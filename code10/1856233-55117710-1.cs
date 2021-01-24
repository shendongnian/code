    // Start off with an object we're going to validate
    public class Foo
    {
    	[MaxLength(5)]
    	public string Bar { get; set; }	
    }
    var objectToValidate = new Foo() { Bar = "123456" };
    // Use reflection to get a list of properties on the object
    var properties = objectToValidate.GetType().GetProperties();
    foreach (var property in properties)
    {
        // For each property, get the attributes defined on that property
        // which derive from the ValidationAttribute base class
        var attributes = property.GetCustomAttributes<ValidationAttribute>();
        var propertyValue = property.GetValue(objectToValidate);
        foreach (var attribute in attributes)
        {
            // For each attribute, call its IsValid method, passing in the value
            // of the property
            bool isValid = attribute.IsValid(propertyValue);
            if (!isValid)
            {
                Console.WriteLine("{0} is invalid", property.Name); 
            }
        }
    }
