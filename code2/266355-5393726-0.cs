    var operation = context.Load(query);
    operation.Completed += (s,ea) => 
    {
        int count = operation.Entities.Count();
        EmployeeGrid.ItemsSource = operation.Entities.ToList();
    }
