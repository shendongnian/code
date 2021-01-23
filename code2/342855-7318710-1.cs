    using System;
    using System.Collections.Generic;
    
    public class Example
    {
        private static int MyRuleComparer(Rule x, Rule y)
        {
          // return -1, 0 or 1 by comparing x & y
        }
    
        public static void Main()
        {
            List<Rule> allRules= new List<Rule>();
            allRules.Add(...);
            allRules.Add(...);
            allRules.Add(...);
            allRules.Add(...);
    
            allRules.Sort(MyRuleComparer);
            
        }
    }
