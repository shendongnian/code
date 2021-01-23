    string str = @"CREATE TABLE [Settings] (
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](100) NOT NULL,
        [Value] [nvarchar](100) NULL
    )
    
    ALTER TABLE [Settings] ADD
        CONSTRAINT [PK_Settings] PRIMARY KEY ([Id])
    
    INSERT INTO [Settings] ([Name, [Value]) VALUES ('SiteUrl', 'http://localhost')
    INSERT INTO [Settings] ([Name], [Value]) VALUES ('AssetsUrl', '/Assets')";
    
    // Replace all [new line] to [space]
    while (str.Contains(Environment.NewLine))
    {
    	str = str.Replace(Environment.NewLine, " ");           
    }
    
    // Array of all sql commands using in query
    string[] sqlCommands = { "CREATE TABLE", "ALTER TABLE", "INSERT INTO" };
    
    // Insert before each sql expression new line
    foreach (string sqlCommand in sqlCommands)
    {
    	str = str.Replace(sqlCommand, Environment.NewLine + sqlCommand);
    }
    
    // Split big sql string to separate commands, and remove empty strings
    string[] arr = str.Split(new string[] { Environment.NewLine },
				StringSplitOptions.None);
    arr = arr.Where(cmd => !String.IsNullOrEmpty(cmd)).ToArray();
    
    // Execute sql commands
    foreach (string command in arr)
    {
    	Console.WriteLine(">> {0}{1}", command, Environment.NewLine);
    }
