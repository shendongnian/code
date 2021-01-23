    var DyObjectsList = new List<dynamic>; 
    if (condition1) { 
        dynamic DyObj = new ExpandoObject(); 
        DyObj.Required = true; 
        DyObj.Message = "Message 1"; 
        DyObjectsList .Add(DyObj); 
    } 
    if (condition2) { 
        dynamic DyObj = new ExpandoObject(); 
        DyObj.Required = false; 
        DyObj.Message = "Message 2"; 
        DyObjectsList .Add(DyObj); 
    } 
