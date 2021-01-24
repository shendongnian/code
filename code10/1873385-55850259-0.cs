    var parentsThatCompletedTheirActionsInTime = dbContext.Parents
        .Where(parent => parent.Status == 99) // = completed
        .GroupJoin(dbContext.ParentActions,   // GroupJoin with the ParentActions
            parent => parent.Id,              // from every Parent take the primary key
        parentAction => parentAction.Id,      // from every ParentAction the foreign key
        // ResultSelector: take the parent and all its matching parentActions
        // to make one new object
        (parent, actionsOfThisParent) => new
        {
            Parent = parent,
            LastParentAction = actionsOfThisParent
               .Select(action => new
               {
                   IsCompleted = action.ActionId == 99,
                   ActionDate = action.ActionDate,
               })
               .OrderByDescending(action => action.ActionDate)               
               .FirstOrDefault(),
        })
        // Keep only those parents where the Last Action was completed in time
        .Where(joinResult => joinResult.LastParentAction.IsCompleted
            && joinResult.LastParentAction.ActionDate >= beginDate
            && joinResult.LastParentAction.ActionDate <= endDate)
        // finally: keep only the Parent:
        .Select(joinResult => joinResult.Parent);
