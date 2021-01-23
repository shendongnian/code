    //Remove spaces from a string just using substring method and a for loop 
    static void Main(string[] args)
    {
    	string businessName;
    	string newBusinessName = "";
    	int i;
    
    	Write("Enter a business name >>> ");
    	businessName = ReadLine();
    
    	for(i = 0; i < businessName.Length; i++)
    	{
    		if (businessName.Substring(i, 1) != " ")
    		{
    			newBusinessName += businessName.Substring(i, 1);
    		}
    	} 
    	
    	WriteLine("A cool web site name could be www.{0}.com", newBusinessName);
    }
