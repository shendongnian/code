        /// <summary>
        /// Indexer which enables accessing rules in the collection by name
        /// </summary>
        /// <param name="ruleName">a rule name</param>
        /// <returns>an instance of a data rule or null if the rule was not found.</returns>
        public IDataRule<TEntity, bool> this[string ruleName]
        {
            get { return Contains(ruleName) ? list[ruleName] : null; }
        }
        // in this case the implementation of the Rules Collection is: 
        // DataRulesCollection<IDataRule<User>> and that generic flows through to the rule.
        // there are also some supporting concepts here not otherwise outlined, such as a "FailedRules" IList
        public bool TestAllRules(User target) 
        {
            rules.FailedRules.Clear();
            var result = true;
            
            foreach (var rule in rules.Where(x => x.IsEnabled)) 
            {
                
                result = rule.Test(target);
                if (!result)
                {
                    
                    rules.FailedRules.Add(rule);
                }
            }
           
            return (rules.FailedRules.Count == 0);
        }
