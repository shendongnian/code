    public class FakePaymentCalculator
    {
        public decimal Price { get; set; }
        public decimal Deposit { get; set; }
        public int Years { get; set; }
        public void GetMonthlyPayment(decimal price, decimal deposit, int years)
        {
            this.Price = price;
            this.Deposit = deposit;
            this.Years = years;
        }
    }
