	var model = new List<Model>{
					
					new Model{Date = new DateTime(2009,1,3), Title = "BTitle 1/3"},
				    new Model{Date = new DateTime(2011,1,31), Title = "BTitle 2/3"},
					new Model{Date = new DateTime(2011,1,1), Title = "BTitle 3/3"},
					
					new Model{Date = new DateTime(2011,1,31), Title = "ATitle XYZ 2of2"},
					new Model{Date = new DateTime(2011,1,31), Title = "ATitle XYZ 1of2"}
					};
			var result = model.OrderBy(x => x.Date).GroupBy(x => x.Prefix);
			Console.WriteLine(result);
