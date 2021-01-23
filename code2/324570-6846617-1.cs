    class CreditInvoice : IExtendPrice
    {
        // ...
        public decimal TotalCreditSumWithoutTax { /* ... */ }
        // Only seen when accessing an instance by its IExtendPrice interface
        decimal IExtendPrice.TotalDebtWithoutTax {
            get { return TotalCreditSumWithoutTax; }
        }
    }
