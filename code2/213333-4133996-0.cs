    class AgentData
    {
    	public AgentData(string name)
    	{
    		Name = name;		
    	}
    	
    	public void SetWeekScore(Dictionary<int, int> weekScore)
    	{
    		WeekScore = weekScore;
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
