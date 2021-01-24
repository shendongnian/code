    class Prop
    {
       public string Name {get;set;}
       public object Value {get;set;}
    }
    
    public void AssignPropertys(object obj, List<Prop> properties)
    {
       var objPropSetters = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(p => p.Name, p => p.GetSetMethod()); // create a dictionary where the key is the property name and the value is the property's setter method
       properties.ForEach(p => objPropSetters[p.Name].Invoke(obj, p.Value)); // Invoke the setter
    }
