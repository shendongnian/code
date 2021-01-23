    public class BalanceCalculator
    {
        readonly IDatabaseInteraction _databaseInteraction;
	
        public BalanceCalculator(IDatabaseInteraction databaseInteraction)
        {
            _databaseInteraction = databaseInteraction;
        }
	
        public Decimal CalcBalance()
        {
        	//Stuff I want to test
        	_databaseInteraction.Interaction();
		
        	return 5.0D;         //This is the value I want to have tested.
        }
    }
