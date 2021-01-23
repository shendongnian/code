    // Decorator
    public class ServiceTaxApplicableCostCalculator 
        : ICostCalculator
    {
        private readonly ICostCalculator with;
        private readonly ICostCalculator without
        ServiceTaxApplicableCostCalculator(
            ICostCalculator with, ICostCalculator without)
        {
            this.with = with;
            this.without = without;
        }
        public double CalculateTotal(Order order)
        {
            bool withTax = this.IsWithTax(order);
            var calculator = withTax ? this.with : this.without;
            return calculator.CalculateTotal(order);
        }
        private bool IsWithTax(Order order)
        {
            // determine if the order is with or without tax.
            // Perhaps by using a config setting or by querying
            // the database.
        }
    }
