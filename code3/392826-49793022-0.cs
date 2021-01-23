    dynamic d = new { Property1= "Value1", Property2= "Value2"};
    
    var properties = d.GetType().GetProperties();
    foreach (var property in properties)
    {
        var PropertyName=property.Name; 
    //You get "Property1" as a result
     
      var PropetyValue=d.GetType().GetProperty(property.Name).GetValue(d, null); 
    //You get "Value1" as a result
    
    // you can use the PropertyName and Value here
     }
