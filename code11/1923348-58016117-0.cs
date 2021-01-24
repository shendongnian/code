    ArgumentNullException: Value cannot be null. Parameter name: connectionString
    Microsoft.EntityFrameworkCore.Utilities.Check.NotEmpty(string value, string parameterName)
    at Microsoft.EntityFrameworkCore.Infrastructure.RelationalOptionsExtension.WithConnectionString(string connectionString)
    at Microsoft.EntityFrameworkCore.MySQLDbContextOptionsExtensions.UseMySQL(DbContextOptionsBuilder optionsBuilder, string connectionString, Action<MySQLDbContextOptionsBuilder> MySQLOptionsAction)
    at VideoClubSharp.Startup.<ConfigureServices>b__4_1(DbContextOptionsBuilder options) in Startup.cs
