    List<Test> objs = new List<Test>()
        {
			new Test(){ Position = "random position 1", IsSet = true, Id = 123 },
			new Test(){ Position = "random position 2", IsSet = true, Id = 123 },
			new Test(){ Position = "random position 3", IsSet = true, Id = 123 }
		};
		
		if(objs.Count() > 1){
			var query = objs.Select(p => new { p.Id, p.IsSet }).Distinct();
			
			var allTheSame = query.Count() == 1;
			
			Console.WriteLine(allTheSame);
		}else{
			
			Console.WriteLine("Nothing To Compare Against");	
		}
	}
