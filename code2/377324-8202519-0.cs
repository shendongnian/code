    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PersonCollection));
    
    string json =  "{\"lastUpdated\":\"16:12\",\"filterOut\":[],\"people\": [{\"ID\":\"a\",\"Name\":\"b\",\"Age\":\"c\"},{\"ID\":\"d\",\"Name\":\"e\",\"Age\":\"f\"},{\"ID\":\"x\",\"Name\":\"y\",\"Age\":\"z\"}], \"serviceDisruptions\": { \"infoMessages\": [\"blah blah text\"], \"importantMessages\": [], \"criticalMessages\": [] } }";
    
    using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
    {
    	var people = (PersonCollection)serializer.ReadObject(stream);
    
    	foreach(var person in people.People)
    	{
    		Console.WriteLine("ID: {0}, Name: {1}, Age: {2}", person.ID, person.Name, person.Age);
    	}
    }	
