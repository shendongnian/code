    public async Task CreateActions(CreateActionDto input)
    {
        Actions actions = new Actions();            
        ActionsDetails actionsdetails = new ActionsDetails();
        // Do your mapping
        MapToEntity(input, actions);
        // Add the details
        foreach (var actionname in input.ActionDetails)
        {
            actionsdetails.ActionName = actionname.ActionName;
            actionsdetails.Description = actionname.Description;
            // Add it to the collection
            actions.ActionsDetails.Add(actionsdetails);
        }
        // Save
        await _actionmanager.CreateActionsAsync(actions);        
    }
