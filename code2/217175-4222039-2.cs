    public void Activate(int Id) 
    { 
        T entity = this.Repository.Select(Id); 
     
        PropertyInfo pi = entity.GetType().GetProperty("MyPropertyName"); 
        var value = (YourType)(pi.GetValue(entity, null));
        // Do somethign with the value...
     
        this.Repository.Submit(); 
    } 
