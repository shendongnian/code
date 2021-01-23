    class AgentsData
    {
    	public static DataTabe ProcessDataTabe(DataTable dt)
    	{
    		Dictionary<string, AgentData> data = new Dictionary<string, AgentData>();
    		
    		for (int i = 0; i < dt.Rows.Count; i++)
    		{
    			string name = dt.rows[i][0].ToString();
    			if (!data.ContainsKey(name))
    				data.Add(name, new AgentData);
    			int week = Convert.ToInt32(dt.rows[i][1]);
    			int score = Convert.ToInt32(dt.rows[i][2]);
    			
    			data[name].Add(week, score);
    		}
    		
    		foreach (vat agentData in data.Values)
    			agentData.Process();
    		
    		//now build new data table from dictionary and return it
    	}	
    }
    
    class AgentData
    {
        public AgentData(string name)
        {
            Name = name;
    		WeekScore = new Dictionary<int,int>();
        }
    
    	public void Add(int weekNumber, int score)
    	{
    		WeekScore[weekNumber] = score;
    	}
    	
        public void Process()
        {
            int min = WeekScore.Keys.Min();
            int max = WeekScore.Keys.Max();
    
            for (int i = 0; i < min; i++)
                WeekScore.Add(i, 0);
    
            for (int i = min + 1; i < max; i++)
                if (!WeekScore.ContainsKey(i))
                    WeekScore.Add(i, -1);
        }
    
        public string Name {get; private set;}  
        public Dictionary<int, int> WeekScore { get; private set;}
    }
