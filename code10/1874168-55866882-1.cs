C#
var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
optionsBuilder.UseSqlite("Data Source=blog.db");
using (var context = new BloggingContext(optionsBuilder.Options))
{
  // do stuff
}
For your SQL Connection
C#
var connection = @"Server=(localdb)\mssqllocaldb;Database=JobsLedgerDB;Trusted_Connection=True;ConnectRetryCount=0";
var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
optionsBuilder.UseSqlServer(connection);
using (var context = new BloggingContext(optionsBuilder.Options))
{
  // do stuff
}
