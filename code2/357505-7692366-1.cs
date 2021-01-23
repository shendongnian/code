    public class Foo
    {
        private decimal CostOfBeverage;
        public void CalcDrinks(bool HealthOption)
        {
            if (HealthOption)
            {
                CostOfBeverage = 5M;
            }
            else
            {
                CostOfBeverage = 20M;
            }
        }
    }
