    class GenericRule {
        int type = 1;
        string name = "Rule";
        public virtual float Calc()
        {
            return 1 + 2 + type; // SAME
        }
    }
    
    class Rule3 : GenericRule
    {
        int type = 3;
        string name = "Rule3";
        public override float Calc()
        {
            return 3 + 4 + type; // DIFFERENT
        }
    }
    
    class Calculator
    {
        public void Do(List<GenericRule> ruleList)
        {
            foreach(var rule in ruleList)
            {
                rule.Calc();
            }
        }
    }
