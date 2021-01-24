public  class YourDbContext : DbContext {
        private readonly IConfiguration _config;
        // See the charset in the end of this string.
		private string _yourConnectionString = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword; CharSet=utf8;";
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseMySQL( _yourConnectionString  );
        }
}
