    private IEnumerable<Permission> GetPermissions(ResourceActionsBase actions)
    {
        if (actions.Use.Value)
            yield return Permission.View;
        if (actions.Modify.Value)
            yield return Permission.Modify;
        if (actions.Delete.Value)
            yield return Permission.Delete;
        if (actions.Assign.Value)
            yield return Permission.Assign;
    }
