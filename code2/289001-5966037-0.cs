    class Zebra
    {
        private int? stripeCount;
        public int StripeCount
        {
            get
            {
                if (this.stripeCount == null)
                {
                    this.stripeCount = ExpensiveCountingMethodThatReallyOnlyNeedsToBeRunOnce();
                }
                return this.stripeCount;
            }
        }
    }
