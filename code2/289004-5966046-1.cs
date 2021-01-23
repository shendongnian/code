    private Lazy<int> MyExpensiveCountingValue = new Lazy<int>(new Func<int>(()=> ExpensiveCountingMethodThatReallyOnlyNeedsToBeRunOnce()));
    		public int StripeCount
    		{
    			get
    			{
    				return MyExpensiveCountingValue.Value;
    			}
    		}
