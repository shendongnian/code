	using (EntityConnection conn = new EntityConnection("name=MyEntities"))
	{
		string str = "SELECT VALUE c " +
					 "FROM BAEntities.Contacts " +
					 "AS c " +
					 "WHERE c IS NOT OF(BAModel.Customer)";
		using (EntityCommand cmd = new EntityCommand(str, conn))
		{                    
			using (var reader = cmd.ExecuteReader())
			{                        
				while (reader.Read())
				{
					Console.WriteLine(reader["c"]);
				}
			}
		}
	}
