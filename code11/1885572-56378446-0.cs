    public static void Main()
    {
    	string neo4jHostname = string.Empty, neo4jUsername = string.Empty, neo4jPassword = string.Empty;
    	IDriver driver = GraphDatabase.Driver(neo4jHostname, AuthTokens.Basic(neo4jUsername, neo4jPassword));
    
    	using (ISession session = driver.Session())
    	{
    		string query = "MATCH (n) RETURN n";
    		IStatementResult resultCursor = session.Run(query);
    		List<IRecord> res = resultCursor.ToList();
    		string values = JsonConvert.SerializeObject(res.Select(x => x.Values), Formatting.Indented);
    		List<JObject> nodes = JsonConvert.DeserializeObject<List<JObject>>(values);
    	}
    }
