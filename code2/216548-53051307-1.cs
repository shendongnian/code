    using (EmployeeContext db= new EmployeeContext())
		{
			var lst = db.Employees.Select(p=> new {
				EmployeeID = p.EmployeeID,
				Name = p.Name,
				Salary = p.Salary,
				Position = p.Position,
				Age = p.Age,
				Office = p.Office
			}).ToList();
			return Json(lst, JsonRequestBehavior.AllowGet);
		}
