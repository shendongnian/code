    var empSales = from emp in Shop.ShopDB.Tables["Employees"].AsEnumerable()
                   join order in Shop.ShopDB.Tables["Orders"].AsEnumerable()
                   on emp.Field<int>("EmployeeID") equals order.Field<int>("EmployeeID")
                   group emp by emp.Field<int>("EmployeeID") into g
                   select new 
				   { 
				       EmployeeID = g.First().EmployeeID,
					   FullName = g.First().FName + " " + g.First().MName + " " + g.First().LName,
					   SalesNumber = g.Count()
				   };
    EmployeesSalesGridView.DataSource = empSales.ToList();
