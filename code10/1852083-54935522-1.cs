    class OraDBContext : DbContext
    {
        public OraDBContext() : base(ORCL1COnnection(), true)
        {
            using (var ctx = this)
            {
                var query = from c_codes in ctx.CountryCodes select c_codes;
            }
        }
    
        public DbSet<CountryCode> CountryCodes { get; set; }
    
        public static OracleConnection ORCL1COnnection()
        {
            var c1 = ConfigurationManager.ConnectionStrings["ORCL1DB"];
            OracleConnection ora_con = new OracleConnection(c1.ConnectionString);
            return ora_con;
        }
    }
