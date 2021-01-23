        public class SalesOrderValidator : BaseValidator, ISalesOrderValidator
        {
            ValidatorResult ValidateParams(CreateSalesOrderParams obj)
            {
				try
				{
					if (obj.Payee == null)
						ValidatorResult.Failiures.Add("You must proivde a Payee");
					if (obj.PaymentAmount == 0)
						ValidatorResult.Failiures.Add("PaymentAmount is 0");                
				}
				catch (Exception)
				{
					ValidatorResult.Failiures.Add("An unexpected error occurred.");
				}
				return base.ValidatorResult;
            }
            ValidatorResult ValidateParams(UpdateSalesOrderParams obj)
            {
			    throw new NotImplementedException();
            }
            ValidatorResult ValidateParams(ApplyDiscountParams obj);
            {
			    throw new NotImplementedException();
            }
        }
