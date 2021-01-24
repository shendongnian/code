      dbug: Microsoft.EntityFrameworkCore.Infrastructure[10401]
            An 'IServiceProvider' was created for internal use by Entity Framework.
      info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
            Entity Framework Core 3.0.0-preview6.19304.10 initialized 'MyContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: None
      dbug: Microsoft.EntityFrameworkCore.Database.Connection[20000]
            Opening connection to database 'Customers' on server '10.0.0.216'.
      dbug: Microsoft.EntityFrameworkCore.Database.Connection[20001]
            Opened connection to database 'Customers' on server '10.0.0.216'.
      dbug: Microsoft.EntityFrameworkCore.Database.Command[20100]
            Executing DbCommand [Parameters=[], CommandType='Text', CommandTimeout='30']
            SELECT COUNT(*)
            FROM [Customers] AS [c]
      dbug: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (42ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            SELECT COUNT(*)
            FROM [Customers] AS [c]
      4
      dbug: Microsoft.EntityFrameworkCore.Database.Command[20300]
            A data reader was disposed.
      dbug: Microsoft.EntityFrameworkCore.Database.Connection[20002]
            Closing connection to database 'Customers' on server '10.0.0.216'.
      dbug: Microsoft.EntityFrameworkCore.Database.Connection[20003]
            Closed connection to database 'Customers' on server '10.0.0.216'.
      dbug: Microsoft.EntityFrameworkCore.Infrastructure[10407]
            'MyContext' disposed.
