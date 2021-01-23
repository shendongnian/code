    SqlDataAdapter sqlClearQuestDefects;
    short retries = 0;
    while(true)
    {
    	try
    	{
    	   sqlClearQuestDefects = new SqlDataAdapter(sql, "Data Source=ab;Initial Catalog=ac;User ID=ad; Password =aa");
             break;
    	}
    	catch(Exception)
    	{
    	   retries++;
             //will try a total of three times before giving up
    	   if(retries >2) throw;    
    	}
    }
