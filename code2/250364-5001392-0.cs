	public class ClassUnderTest
	{
		public IManager Manager {get;set;}
		public IMessanger Messanger {get;set}
		
		private void CheckToDate(DateTime ToDate)
		{
			if (Manager.MaxToDate < ToDate.Year)
				//show a custom message
				Messanger.ShowMessage('message');
		}
	}
