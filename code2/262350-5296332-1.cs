        public class PaymentService
		{
			IDalService theDal;
			public PaymentService(IDalService dal) {theDal = dal;};
			
			CheckCreditlimit(Customer ...)
			{
			     ....
				 theDal.GetCreditdata(...);
			}
		}
		
