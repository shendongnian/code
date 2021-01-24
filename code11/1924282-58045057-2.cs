	class MyModel
    {
      public int MyFirstInputValue {get; set;}
	  public int MySecondInputValue {get; set;}
	
 	  public int MyFirstResultValue {get; private set;}
	  public int MySecondResultValue {get; private set;}
	
	  public void RunMyCalculationLogic()
 	  {
		// your calculations go here...
		MyFirstResultValue = MyFirstInputValue + MySecondInputValue;
		MySecondResultValue = MyFirstInputValue - MySecondInputValue;
  	  }
    }
