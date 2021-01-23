	public class ClassUnderTest
	{
		public IManager Manager {get;set;}
		public IMessanger Messanger {get;set}
		
		public  ClassUnderTest (IManager manager, IMessanger messanger)
		{
			Manager = manager;
			Messanger = messanger;
		}
		private void CheckToDate(DateTime ToDate)
		{
			if (Manager.MaxToDate < ToDate.Year)
				//show a custom message
				Messanger.ShowMessage('message');
		}
	}
