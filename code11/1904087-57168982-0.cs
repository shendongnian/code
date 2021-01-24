     public string Description
     {
        get
        {
                return FinanceInvoice == null
                           ? null
                           : $"Payment for {FinanceInvoice.Invoice_Number} Thank You";
        }
      }
