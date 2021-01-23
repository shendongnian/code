    public DbSet<Dim_Date> Dim_Date { get; set; }
    	public DbSet<Dim_Player> Dim_Player { get; set; }
    	public DbSet<Dim_Team> Dim_Team { get; set; }
    	public DbSet<Fact_Statistics> Fact_Statistics { get; set; }
    	public DbSet<Dim_Game> Dim_Game { get; set; }
    
    	public virtual ObjectResult<ListLeagueLeaders_Result> ListLeagueLeaders()
    	{
    		((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(ListLeagueLeaders_Result).Assembly);
    
    		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListLeagueLeaders_Result>("ListLeagueLeaders");
    	}
