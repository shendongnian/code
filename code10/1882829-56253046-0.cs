    public static class Program
    {
    	private static void Main(string[] args)
    	{
    		string data = @"
    			[
    					{
    						'videogame_versions': [
    							'9.10.1',
    							'9.9.1',
    							'9.8.1',
    							'9.7.2',
    							'9.7.1',
    							'9.6.1',
    							'9.5.1',
    							'9.4.1',
    							'9.3.1',
    							'9.2.1',
    							'9.1.1',
    							'8.24.1',
    							'8.23.1',
    							'8.22.1'
    						],
    						'spellblockperlevel': 0.5,
    						'spellblock': 30,
    						'name': 'Brand',
    						'mpregenperlevel': 0.6,
    						'mpregen': 10.665,
    						'mpperlevel': 21,
    						'mp': 469,
    						'movespeed': 340,
    						'image_url': 'https://cdn.pandascore.co/images/lol/champion/image/7aa667709a7ce82e45c459e3df2d160a.png',
    						'id': 2347,
    						'hpregenperlevel': 0.55,
    						'hpregen': 5.5,
    						'hpperlevel': 88,
    						'hp': 519.68,
    						'critperlevel': 0,
    						'crit': 0,
    						'big_image_url': 'https://cdn.pandascore.co/images/lol/champion/big_image/8ba7fd90e7c250b2dcc3183205ad6d94.jpg',
    						'attackspeedperlevel': 1.36,
    						'attackspeedoffset': null,
    						'attackrange': 550,
    						'attackdamageperlevel': 3,
    						'attackdamage': 57.04,
    						'armorperlevel': 3.5,
    						'armor': 21.88
    					}
    				]
    		";
    
    		List<Champions> champions = JsonConvert.DeserializeObject<List<Champions>>(data);
    	}
    
    	public class Champions
    	{
    		public List<string> videogame_versions { get; set; }
    		public double spellblockperlevel { get; set; }
    		public double spellblock { get; set; }
    		public string name { get; set; }
    		public double mpregenperlevel { get; set; }
    		public double mpregen { get; set; }
    		public double mpperlevel { get; set; }
    		public double mp { get; set; }
    		public double movespeed { get; set; }
    		public string image_url { get; set; }
    		public int id { get; set; }
    		public double hpregenperlevel { get; set; }
    		public double hpregen { get; set; }
    		public double hpperlevel { get; set; }
    		public double hp { get; set; }
    		public double critperlevel { get; set; }
    		public double crit { get; set; }
    		public string big_image_url { get; set; }
    		public double attackspeedperlevel { get; set; }
    		public object attackspeedoffset { get; set; }
    		public double attackrange { get; set; }
    		public double attackdamageperlevel { get; set; }
    		public double attackdamage { get; set; }
    		public double armorperlevel { get; set; }
    		public double armor { get; set; }
    	}
    }
