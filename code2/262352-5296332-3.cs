        public class PaymentService
		{
			IDAL theDal;
			public PaymentService(IDAL dal) {theDal = dal;};
			
			SavePayment(...)
			{
				 theDal.Save(...);
			}
		}
		
