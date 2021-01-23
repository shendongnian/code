    var myTable = new [] {
				new {Field1 = "a", Field2 = "b", Field3 = "c", Field4 = "d"},
				new {Field1 = "a", Field2 = "b", Field3 = "c", Field4 = "d"}
			};
					
			var myQuery = (from v in myTable
						   select new MainClass()
						   {
							MainKey = v.Field1,
							MainName = v.Field2,
							MainList = new List<SmallObject>{
								new SmallObject {SmallKey = v.Field3},
								new SmallObject {SmallKey = v.Field4},
							}
						   });
