    switch (sort)
    {
    case 1:
        issues = issues.OrderBy(x => x.Customer);
        break;
    case 2:
        issues = issues.OrderBy(x => x.Description);
        break;
    case 3:
        issues = issues.OrderBy(x => x.CreatedBy);
        break;
    default:
        issues = issues.OrderBy(x => x.DueDateTime);
        break;
    }
