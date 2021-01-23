    var parent = new ParentType();
    
    var mixedList = parent.ChildTypes
                      .Select(c => new MixedType
                      {
                         ParentID = parent.ID,
                         ParentName = parent.Name,
                         ChildID = c.ID,
                         ChildName = c.Name
                                                  
                      });
