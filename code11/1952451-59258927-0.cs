    // overload constructer
     public MyContext(DbConfig dbconfig)
    {
       _dbconfig = dbconfig
    }
    	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				switch (_dbConfig.DbType)
				{
					case DbTypes.MsSql:
						optionsBuilder.UseSqlServer(_dbConfig.ConnectionString);
						break;
					case DbTypes.PostgreSql:
						optionsBuilder.UseNpgsql(_dbConfig.ConnectionString);
						break;
                    case DbTypes....
                    .....
				}
				optionsBuilder.EnableSensitiveDataLogging();
			}
		}
 
