    public float NetSalary
    {
    	get
    	{
    		float netSalary;
    		float tax = 0.8;
    
    		if (taxDeducted)
    			{
    			netSalary = salary * tax;
    
    			}
    		else
    			{
    			netSalary = salary;
    			}
    
    		return netSalary;
    	}
    }
