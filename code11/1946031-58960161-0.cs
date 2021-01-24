    public SqlConnection conn { get; set; }
    public DbContext()
    {
    #if DEBUG
    	conn = new SqlConnection(Properties.Settings.Default.ConnString_A);
    #else
    	conn = new SqlConnection(Properties.Settings.Default.ConnString_B);
    #endif
    }
