        public class PaymentService
		{
			public PaymentService();
			
			SavePayment( ...)
			{
                             IDAL dal = ioCContainer.resolve<IDAL>();
                             dal.Save(...);
			}
		}
		
