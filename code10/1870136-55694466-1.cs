    var search = new Search(new[] {
    		new MyClass { Name = "Test 1", Child = new SubClass { SubClassName = "Bob" }},
    		new MyClass { Name = "Test 2", Child = new SubClass { SubClassName = "Subclass"}},
    		new MyClass { Name = "Test 3", Child = new SubClass { SubClassName = "Subclass"}}
    	});
    
    	search.Find(k => k.SubClassName == "Subclass");
