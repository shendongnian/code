	// in data helper class
	public void CallData(DataHelper.DataCalledEventHandler functor)
	{
		List<DataItem> dataItems = new List<DataItem>();
		//SOME CODE THAT RETURNS DATA
		functor(this, dataItems);
	}
	    
	// in your function
	...    dataHelper.CallData(this.dataHelper_DataCalled);    ...
