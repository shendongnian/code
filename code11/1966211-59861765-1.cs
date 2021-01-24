    public static string connstring = "";
    public static string Set(IConfiguration config)
        {
            connstring = config.GetConnectionString("MyConnection");
        }
