    var match = PredicateBuilder.New<User>(true);
    match = match.And(o => o.Name == viewModel.Name);
    match = match.And(o =>orders.Contains(o.User.Company.CompanyId.ToString()));
    if(viewModel.dept==1 || viewModel.dept == 2 || viewModel.dept==3)
    {
        match = match.And(o=>o.dept == viewModel.dept);
    }
    return match;
