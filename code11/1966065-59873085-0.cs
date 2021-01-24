    var data = new []
    		{ 
    			new SampleData{ ID = 1, Tags = new []{ "acronym", "address" }, Name = "one" },
    			new SampleData{ ID = 2, Tags = new []{ "applet", "abbr", "embed" }, Name = "two" },
    			new SampleData{ ID = 3, Tags = new []{ "iframe", "abbr" }, Name = "three" },
    			new SampleData{ ID = 4, Tags = new []{ "abbr", "bgsound", "bdo" }, Name = "four" },
    			new SampleData{ ID = 5, Tags = new []{ "img", "acronym" }, Name = "five" },
    		};
    		var orderedKeyMapping = data.SelectMany(p => p.Tags).GroupBy(tag => tag).ToDictionary(g => g.Key, g => g.Count()).OrderByDescending(p => p.Value);
    		var result = data.Select(p => new 
    								 { 
    									 SampleData = p,  
    									 Weight = orderedKeyMapping.FirstOrDefault(o => p.Tags.Any(tag => o.Key.Equals(tag))).Value
    								 }).OrderByDescending(p => p.Weight)
    			                       .Select(p => p.SampleData); 
    		
    		Console.WriteLine(JsonConvert.SerializeObject(result));
