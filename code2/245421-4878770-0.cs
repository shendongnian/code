    Contracts.GroupDto IDashboardService.GetGroupById(string groupId)
    {
        switch ((DashboardGroupType)groupId)
        {
            case DashboardGroupType.Regions:
                // Get the Regions list, convert to JSON, and return.
                break;
            // do the same kind of thing for the other group types.
        }
    }
