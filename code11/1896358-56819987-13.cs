    var orderedActions = ActionsList
        .Where(a => a.IsActive)
        .OrderBy(a => a.Order)
        .ToList();
    foreach (MyObjects o in myObjects) {
        foreach (MyAction action in orderedActions) {
            action.Action(o);
        }
    }
