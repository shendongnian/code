    public void test()
    {
    	try
    	{
    		using (var context = new ClientContext(webSPOUrl))
    		{
    			context.Credentials = new NetworkCredential("username", "password", "domain");
    			Web web = context.Web;
    			context.Load(web, website => website.Title);
    			context.Load(web.Webs);
    			context.Load(web.Lists,
    				lists => lists.Include(list => list.Title,
    					list => list.Id));
    
    			context.ExecuteQuery();
    			Console.ForegroundColor = ConsoleColor.White;
    			foreach (List list in web.Lists)
    			{
    				Console.WriteLine("List title is: " + list.Title);
    			}
    			Console.WriteLine("");
    
    		}
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine("Error is: " + ex.Message);
    	}
    }
