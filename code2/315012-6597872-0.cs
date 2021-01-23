    void Function()
    {
    	... some code here ....
    	
    	{	// inside this bracket the usersCollection is alive
    	    // at the end of the bracet the garbage collector can take care of it
    		
    		List<User> usersCollection =new List<User>();
    
    		User user1 = new User();
    		User user2 = new User()
    
    		userCollection.Add(user1);
    		userCollection.Add(user2);
    
    		foreach(User user in userCollection)
    		{
    			
    		}
    	}
    	
    	... other code here ....
    }
