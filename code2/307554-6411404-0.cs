    System.Reflection.Assembly assem = Assembly.Load("");
    object thisObj = assem.CreateInstance("Customers");
    foreach (PropertyInfo pi in thisObj.GetType().GetProperties)
    {
       // List all properties in object 
       ...
    }
