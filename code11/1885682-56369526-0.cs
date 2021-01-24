    var tableB = new TableB
    {
        UserId = userNum.Id,
        Address = viewModel.Address,
        City = viewModel.City,
        State = viewModel.State,
        CellPhone = viewModel.CellPhone,
        Department = viewmodel.Department,
        CostCenter = viewmodel.CostCenter,
        ZipCode = viewModel.ZipCode
    };
    db.MyTableB.Add(tableB);
