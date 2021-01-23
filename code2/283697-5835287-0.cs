    var hats = new List<Hat>
    	{
    		new Hat { Name = "Cool Hat", Color = "Red" }, 
    		new Hat { Name = "Funky Hat", Color = string.Empty }
    	};
    
    using (var stream = new FileStream("test.txt", FileMode.Truncate))
    {
    	var serializer = new XmlSerializer(typeof(List<Hat>));
    	serializer.Serialize(stream, hats);
    }
