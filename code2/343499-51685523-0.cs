    <add name="MyConnection"
    connectionString="metadata=res://*/Entities.ModuleA.csdl|res://*/Entities.ModuleA.ssdl|res://*/Entities.ModuleA.msl|res://*/Entities.ModuleB.csdl|res://*/Entities.ModuleB.ssdl|res://*/Entities.ModuleB.msl;
    provider=System.Data.SqlClient;provider connection string=&quot;MyConnectionString&quot;"
    providerName="System.Data.EntityClient" />
    
    using (EntityConnection oEntityConnection =
    	new EntityConnection("name=MyConnection"))
    {
    	using(DbContext oDBContext = new DbContext(oEntityConnection))
    	{
    		//your code - available are entities declared in Entities.ModuleA and Entities.ModuleB
    	}
    }
