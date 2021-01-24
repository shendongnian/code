        public bool enableDisableList = false;
    
        [ShowIf(ActionOnConditionFail.JustDisable, ConditionOperator.And, 
        nameof(enableDisableList))]
        public string anotherField = "item 2";
