    For example, if I want to use a Microsoft SQL Server function like CURRENT_USER and try to insert like this:
    
    Insert.IntoTable("Users").Row(new { Username = "CURRENT_USER" });
    The result will be that the Username column will get the value CURRENT_USER as a string. To execute the function you can use the RawSql.Insert method like this:
    
    Insert.IntoTable("User").Row(new { Username = RawSql.Insert("CURRENT_USER") });
    This will result in the Username column being set to the current username. Be aware that by using an sql server specific function like CURRENT_USER that this expression is not portable anymore and will not work against another database (like PostgreSQL).
