    public static IEnumerable<Person> GetPeople()
    {
    	using( var conn = GetConnection() )
    	{
    		conn.Open();
    		string sql = "SELECT name, age FROM person";
    		var cmd = new SqlCommand( sql, conn );
    
    		using( SqlDataReader rdr = cmd.ExecuteReader() )
    		{
    			if( rdr == null )
    			{
    				throw new NullReferenceException( "No People Available." );
    			}
    			while( rdr.Read() )
    			{
    				var person = new Person();
    				person.Name = rdr["name"].ToString();
    				person.Age = Convert.ToInt32 ( rdr["age"] );
    				
    				yield return person;
    			}			
    		}
    	}
    }
