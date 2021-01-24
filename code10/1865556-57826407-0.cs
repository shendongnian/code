services.AddLogging(loggingBuilder => {
    loggingBuilder.AddConsole()
        .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
    loggingBuilder.AddDebug();
});
Now update your DBContext to enable the sensitive data logging,
services.AddDbContext<MyDbContext>(options => {
    options.UseSqlServer(_configuration.GetConnectionString("MyDbConnection"));
    options.EnableSensitiveDataLogging(true);
});
Once you've configured your startup, you will now see the SQL commands and their sensitive data appear in our Output window in Visual Studio (Debug...Windows...Output) as shown below,
Microsoft.EntityFrameworkCore.Database.Command:Information: Executed DbCommand (3ms) 
    [Parameters=[@p1='aaa' (Nullable = false) (Size = 450), 
                 @p2='bbb' (Size = 4000), 
                 @p0='New Column Value' (Size = 4000)], 
    CommandType='Text', CommandTimeout='30']
SET NOCOUNT ON;
UPDATE [MyTableName] SET [MyColumnName] = @p0
WHERE [Id] = @p1 AND [OtherColumn] = @p2;
SELECT @@ROWCOUNT;
It took me a while to figure this out as well.  I could not get the sensitive data to appear in the log using the OnConfiguring in the DBContext class either.
Hope this helps even though it's using SQL Server and not MySQL.
**NOTE!**  Be sure to disable sensitive data logging when deploying to production.
