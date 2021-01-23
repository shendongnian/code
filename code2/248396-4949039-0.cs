    void Main()
    {
    	var p = new Player("David");
    	var c = new Championship("Chess");
    	p.LinkChampionship(c, DateTime.Now);
    	
    	p.Dump();
    }
    
    // Define other methods and classes here
    
    class Player : Properties {
    	public virtual String Name {get; set;}
    	public List<ChampionshipWrapper> champs = new List<ChampionshipWrapper>();
    	
    	public Player() {
    	}
    	public Player(string name) {
    	    Name = name;
    	}
    	public void LinkChampionship(Championship champ, DateTime when) {
    		var p = new Properties(when);
    		champs.Add(new ChampionshipWrapper(champ, p));
    		champ.players.Add(new PlayerWrapper(this, p));
    	}
    }
    
    class Championship : Properties {
    	public virtual String Name { get; set; }
    	public List<PlayerWrapper> players = new List<PlayerWrapper>();
    	
    	public Championship(){}
    	public Championship(string name) {
    	    Name = name;
    	}
    
    	public void LinkPlayer(Player play, DateTime when) {
    		var p = new Properties(when);
    		players.Add(new PlayerWrapper(play, p));
    		play.champs.Add(new ChampionshipWrapper(this, p));
    	}
    }
    
    class Properties {
        public virtual DateTime LastPlayed { get; set; }
    	public Properties() {
    	}
    	public Properties(DateTime when) {
    	    LastPlayed = when;
    	}
    }
    
    class PlayerWrapper : Player {
    	private Player player;
    	private Properties props;
    
    	public PlayerWrapper(Player play, Properties prop) {
    		this.player = play;
    		this.props = prop;
    	}
    
    	public override String Name {
    		get { return this.player.Name; }
    		set { this.player.Name = value; }
    	}
    	
    	public override DateTime LastPlayed { 
    	    get { return this.props.LastPlayed; }
    		set { this.props.LastPlayed = value; }
    	}
    }
    
    class ChampionshipWrapper : Championship {
    	private Championship champ;
    	private Properties props;
    
    	public ChampionshipWrapper(Championship c, Properties prop) {
    		this.champ = c;
    		this.props = prop;
    	}
    
    	public override String Name {
    		get { return this.champ.Name; }
    		set { this.champ.Name = value; }
    	}
    	
    	public override DateTime LastPlayed { 
    	    get { return this.props.LastPlayed; }
    		set { this.props.LastPlayed = value; }
    	}	
    }
