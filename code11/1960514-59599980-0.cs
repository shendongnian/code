    .Select(m => new History
    {
        CostCenterID=(int)m.CostCenterID,
        CostCenterOwner= m.Owner
    });
