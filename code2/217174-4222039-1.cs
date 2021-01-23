    public void Activate(int Id) 
    { 
        T Entity = this.Repository.Select(Id); 
     
        PropertyInfo pi = Entity.GetType().GetProperty("MyPropertyName"); 
        var value = (YourType)(pi.GetValue(Entity, null));
     
        this.Repository.Submit(); 
    } 
