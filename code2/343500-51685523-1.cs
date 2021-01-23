     using (EntityConnection oEntityConnection =
        	new EntityConnection(new MetadataWorkspace(
        	new string [] { 
    "res://Entities.ModuleA/", 
    "res://Entities.ModuleB/" 
    },
        	new Assembly[] { 
    Assembly.GetAssembly(typeof(Entities.ModuleA.AnyType)),
    Assembly.GetAssembly(typeof(Entities.ModuleB.AnyType)) 
    }
        	)))
        {
        	using(DbContext oDBContext = new DbContext(oEntityConnection))
        	{
        		//your code - available are entities declared in Entities.ModuleA and Entities.ModuleB
        	}
        }
