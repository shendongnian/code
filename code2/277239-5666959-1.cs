    public void MyMethod(InputClass myInput)
    {
    	TaskFactory<object> t = new TaskFactory<object>();
    	
    	var result = method1(myInput);	// Execute Synchronously
    	
    	Task<object> t1 = t.StartNew(method2, result); // Create and start new concurrent task
    	Task<object> t2 = t.StartNew(method3, result); // Create and start new concurrent task
    	
    	t1.Wait(); //Wait for completion
    	t2.Wait(); //Wait for completion
    	
    	var finalResult = method4(t1.Result, t2.Result);  // Execute Synchronously
    }
