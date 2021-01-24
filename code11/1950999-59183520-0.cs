    using (var session = sessionFactory.OpenSession())
    {
    	using (var transaction = session.BeginTransaction())
    	{
    		try
    		{
    			foreach (var item1 in data1)
    			{
    				session.Save(item1);
    			}
    			session.Flush(); // execute all the queries for the itens (1)
    
    			foreach (var item2 in data2)
    			{
    				session.Save(item2);
    			}
    			session.Flush(); // execute all the queries for the itens (2)
    
    			transaction.Commit();
    		}
    		catch (Exception e)
    		{	
    			transaction.RollBack();
    			// do some log with `e` exception reference
    		}
    	}
    }
