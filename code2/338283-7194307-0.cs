		public void GetSomeData1(DataParameters[] parameters, Action responseHandler)
		{
		  Transactions.GetSomeData1(response => SomeData1ResponseHandler(response, responseHandler), parameters);
		}
		
		private void SomeData1ResponseHandler(Response response, Action responseHandler)
		{
		  if (response != null)
		  {
		    CreateSomeData1(response.Data, responseHandler);
		  }
		}
		
		public void CreateSomeData1(Data data, Action responseHandler)
		{
		  //Create the objects and then invoke the Action
		  ...
		
		  if(responseHandler != null)          
		  {
		    responseHandler();
		  }
		}
