    [WebMethod]
        public List<Payment> GetPayments(string firstDate, string lastDate, string entegrationStatus)
        {
            if (Common.IsDateTime(firstDate) && Common.IsDateTime(firstDate) && Common.IsValidEntegrationStatus(entegrationStatus))
            {
                return paymentManager.GetPayments(firstDate, lastDate, entegrationStatus);
            }
            else
            {
                throw new ArgumentException("Your error message.");
            }
        }
