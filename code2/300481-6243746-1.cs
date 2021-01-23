    void Main()
    {
    	var model = new List<Model>{new Model{Date = new DateTime(2011,1,3), Title = "Some Title 1/3"},
    				new Model{Date = new DateTime(2011,1,1), Title = "Some Title 2/3"},
    					new Model{Date = new DateTime(2011,1,1), Title = "Some Title 3/3"},
    					new Model{Date = new DateTime(2011,1,31), Title = "Title XYZ 1of2"},
    					new Model{Date = new DateTime(2011,1,31), Title = "Title XYZ 2of2"}};
    			var result = model.OrderBy(x => x.Date).GroupBy(x => x.Prefix);
    			Console.WriteLine(result);
    }
