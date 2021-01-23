    RequestFactory
    {
    	public static T Create<T>(string firstName, string lastName)
    		where T : Request, new()
    	{
    		var request = new T();
    		request.FirstName = firstName;
    		request.LastName = lastName;
    		
    		return request;
    	}
    }
    var employeeRequest = RequestFactory.Create<EmployeeRequest>("joe", "smith");
