    public interface IDataRule<TEntity> 
    {
        /// <summary>
        /// Evaluates the validity of a rule given an instance of an entity
        /// </summary>
        /// <param name="entity">Entity to evaluate</param>
        /// <returns>result of the evaluation</returns>
        bool Test(TEntity entity);
        /// <summary>
        /// The unique indentifier for a rule.
        /// </summary>
         int RuleId { get; set; }
        /// <summary>
        /// Common name of the rule, not unique
        /// </summary>
         string RuleName { get; set; }
        /// <summary>
        /// Indicates the message used to notify the user if the rule fails
        /// </summary>
         string ValidationMessage { get; set; }   
         /// <summary>
         /// indicator of whether the rule is enabled or not
         /// </summary>
         bool IsEnabled { get; set; }
        /// <summary>
        /// Represents the order in which a rule should be executed relative to other rules
        /// </summary>
         int SortOrder { get; set; }
    }
