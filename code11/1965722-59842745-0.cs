    var InfoInOne = new List<One>() { new One { IdInOne = "A", NameInOne = "A" }, new One { IdInOne = "B", NameInOne = "B" }  };
    var InfoInTwo = new List<Two>() { new Two { IdInTwo = "A", NameInTwo = "A" }, new Two { IdInTwo = "C", NameInTwo = "C" }  };
    
    var q = from one in InfoInOne
    		join two in InfoInTwo on new { Id = one.IdInOne, Name = one.NameInOne } equals 
                                     new { Id = two.IdInTwo, Name = two.NameInTwo } into g
    		from two in g.DefaultIfEmpty()
    		select new {One = one, Two = two};
    
    foreach (var item in q)
    {
    	if(item.Two != null)
    		Console.WriteLine("Item found");
    	else
    		Console.WriteLine("Item not found");
    }
