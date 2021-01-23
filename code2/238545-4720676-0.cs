    protected override void CreateChildControls()         
    {                      
     if(!ispostback){
     assignedItemsField = new HiddenField();     
     assignedItemsField.ID = "HiddenAssignedItems";
     assignedItemsField.EnableViewState = true;          
     unassignedItemsField = new HiddenField();           
     unassignedItemsField.ID = "HiddenUnassignedItems"; 
     unassignedItemsField.EnableViewState = true;      
     Controls.Add(assignedItemsField);             
     Controls.Add(unassignedItemsField);          
     base.CreateChildControls();      
    }
     }
