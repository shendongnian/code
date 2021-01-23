	public class ClientCode
	{
		public void DisplayPaymentsOnScreen()
		{
			Payment[] payments;
        
			using (var repository = new Repository())
			{
				payments = repository.GetPayments().Where(p => p.Amount > 100).ToArray();
			}
			// Do stuff with the data here...
		}
	}
