    var x = new ResponseGradeDto{ 
    		Id = Guid.NewGuid(), 
    		Name = "Foo",
    		Code = "Cde",
    		Information = "No info"
    };
    	
    using (var writer = new StreamWriter(@"C:\temp\log.txt"))
    {
    	writer.WriteLine(x.Name);
    	writer.WriteLine(x.Code);
    	writer.WriteLine(x.Information);
    }
