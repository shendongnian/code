    using (InventoryContext db = new InventoryContext ())
     {
       Employee employee = new Employee();
       employee.EmployeeID = Convert.ToInt32(ddlOperators.SelectedValue);
       var wareHouseId = Convert.ToInt32(ddlWarehouses.SelectedValue);
       var operator = new Operator();
       operator.EmployeeID = employee.EmployeeID ;
       operator.Warehouses.add(new Warehouse(){Id=wareHouseId});
       db.Operator.Add(operator);
    
       db.SaveChanges();                       
       ddlOperators.DataBind();
    }         
