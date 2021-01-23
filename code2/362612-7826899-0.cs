    this.AvailableRoles = CurrentItem.MEMGroupRoles
        .Select(g => g.MEMRole)
        .Concat(this.allRoles)
        .GroupBy(r => r.RoleId)
        .Where(g => g.Count() == 1)
        .Select(g => g.First());
