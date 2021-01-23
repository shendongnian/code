    /// <summary>
    /// this class contains a batch of ActionResult to execute
    /// </summary>
    public class PortalMultipleActionResult : ActionResult
    {
        /// <summary>
        /// Builds a new instance of PortalMultipleActionResult
        /// </summary>
        /// <param name="results"></param>
        public PortalMultipleActionResult(IEnumerable<ActionResult> results)
        {
            Results = results;
        }
    
        /// <summary>
        ///  Builds a new instance of PortalMultipleActionResult
        /// </summary>
        /// <param name="actions"></param>
        public PortalMultipleActionResult(IEnumerable<Action> actions)
        {
            Results = actions.Select(x => new PortalActionDelegateResult(x));
        }
    
        /// <summary>
        /// Batch execution of all the results
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            foreach (var res in Results)
            {
                res.ExecuteResult(context);
            }
        }
    
        /// <summary>
        /// Action results collection
        /// </summary>
        private IEnumerable<ActionResult> Results
        {
            get;
            set;
        }
    }
