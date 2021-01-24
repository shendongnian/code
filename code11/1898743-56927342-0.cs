	int baseDamage = 2;
	
	class PlayerClass
	{
		public int Health = 10;
		public int WaterStrength = 1;
		public int FireStrength = 1;
	}
	
	private Dictionary<string, Func<PlayerClass, int>> indirect = new Dictionary<string, Func<PlayerClass, int>>()
	{
		{ "WaterStrength", pc => pc.WaterStrength },
		{ "FireStrength", pc => pc.FireStrength },
	};
	
	void AnalyzeRound(PlayerClass won, PlayerClass lost, string winningElement)
	{
		int strength = indirect[winningElement + "Strength"](won);
		lost.Health -= baseDamage * strength;
	}
