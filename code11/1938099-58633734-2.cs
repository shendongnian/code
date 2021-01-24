        class BillingService
        {
            public void Print(TotalCalculations calc)
            {
                //when calling the method, you can use the standard Label                
                string original = calc.SumAggregatoryFactory().ToString();
                 //or take only the sum and configure the result string yourself
                string custom = $"My message: {calc.SumAggregatoryFactory().SumAmount}";
            }
        }
