    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class SubactionAttribute : ActionMethodSelectorAttribute
    {
        #region Properties
     
        /// <summary>
        /// Gets subaction name.
        /// </summary>
        public string Name { get; private set; }
     
        #endregion
     
        #region Constructors
     
        /// <summary>
        /// Initializes a new instance of the <see cref="SubactionAttribute"/> class.
        /// </summary>
        public SubactionAttribute()
            : this(null)
        {
    		// does nothing
        }
     
        /// <summary>
        /// Initializes a new instance of the <see cref="SubactionAttribute"/> class.
        /// </summary>
        /// <param name="subactionName">Sub-action name</param>
        public SubactionAttribute(string subactionName)
        {
            this.Name = subactionName;
        }
     
        #endregion
     
        #region ActionMethodSelectorAttribute implementation
     
        /// <summary>
        /// Determines whether the action method selection is valid for the specified controller context.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="methodInfo">Information about the action method.</param>
        /// <returns>
        /// true if the action method selection is valid for the specified controller context; otherwise, false.
        /// </returns>
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
    		
    		// get the value of subaction here
    		string subName = /* this part you'll have to write */
     
            // determine whether subaction matches
            return this.Name == subName;
        }
     
        #endregion
    }
