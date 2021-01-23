    var objectsToBindToDropdown = businessObjects.Select(o => new 
        {
            SomeProperty1 = o.BusinessProperty1, 
            SomeProperty2 = o.BusinessProperty2
        });
    
    dropDownList.DataTextField  = "SomeProperty1";
    // TODO: bind the drop down list
