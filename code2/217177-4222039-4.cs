    public void Activate(int Id) 
    { 
        T entity = this.Repository.Select(Id); 
     
        // Interrogate the type of the entity and get the property called "MyPropertyName"
        PropertyInfo pi = entity.GetType().GetProperty("MyPropertyName"); 
        // Invoke the property against the entity instance - this retrieves the 
        // value of the property.
        var value = (YourType)(pi.GetValue(entity, null));
        // Do somethign with the value...        
             
        this.Repository.Submit(); 
    } 
