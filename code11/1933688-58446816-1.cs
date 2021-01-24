        [ShowIf(ActionOnConditionFail.JustDisable, ConditionOperator.And,nameof(CalculateIsEnabled))]
    	public string yetAnotherField = "one more";    public 
        bool CalculateIsEnabled()    
    	{
            return true;    
    	}
