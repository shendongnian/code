    declare @sql nvarchar(max)
    
    set @sql = 'SELECT 
    [Extent1].[Id] AS [Id]
    FROM [dbo].[Main] AS [Extent1]
    WHERE [Extent1].[Id] IN ('
    
    declare @count int = 0
    while @count < 10000
    begin
    	if @count > 0 set @sql = @sql + ','
    	set @count = @count + 1
    	set @sql = @sql + cast(@count as nvarchar)
    end
    set @sql = @sql + ')'
    
    exec(@sql)
------
    var ids = Mains.Select(a => a.Id).ToArray();
    
    var sb = new StringBuilder();
    sb.Append("SELECT [Extent1].[Id] AS [Id] FROM [dbo].[Main] AS [Extent1] WHERE [Extent1].[Id] IN (");
    for(int i = 0; i < ids.Length; i++)
    {
    	if (i > 0) 
    		sb.Append(",");		
    	sb.Append(ids[i].ToString());
    }
    sb.Append(")");
    
    using (SqlConnection connection = new SqlConnection("server = localhost;database = Test;integrated security = true"))
    using (SqlCommand command = connection.CreateCommand())
    {
    	command.CommandText = sb.ToString();
    	connection.Open();
    	using(SqlDataReader reader = command.ExecuteReader())
    	{
    		while(reader.Read())
    		{
    			Console.WriteLine(reader.GetInt32(0));
    		}
    	}
    }
