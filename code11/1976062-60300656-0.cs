    var MyValue = "bar";
    var MyObject = new
    {
        foo = MyValue
    };
    // using Newtonsoft.Json; // <--- taken from the nugget package newtonsoft.json
	var json = JsonConvert.SerializeObject(MyObject, Formatting.Indented);
	Console.WriteLine(json);
