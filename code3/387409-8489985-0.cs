    var dict = (
    	from t in typeof(ImageFormat).GetProperties()
    	where t.PropertyType == typeof(ImageFormat)
    	let v = (ImageFormat)t.GetValue(null, new object[0])
    	select new { v.Guid, t.Name }
    	).ToDictionary(g => g.Guid, g => g.Name);
    	
    string name;
    if (dict.TryGetValue(ImageFormat.Png.Guid, out name))
    {
    	Console.WriteLine(name);
    }
