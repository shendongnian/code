    /// <summary>
    /// Extension methods for <see cref="Action"/> objects.
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Executes the <paramref name="action"/> and ignores any exceptions.
        /// </summary>
        /// <remarks>
        /// This should be used in very rare cases.
        /// </remarks>
        /// <param name="action">The action to execute.</param>
        public static void IgnoreExceptions(this Action action)
        {
            try { action(); }
            catch { }
        }
        /// <summary>
        /// Extends an existing <see cref="Action"/> so that it will ignore exceptions when executed.
        /// </summary>
        /// <param name="action">The action to extend.</param>
        /// <returns>A new Action that will ignore exceptions when executed.</returns>
        public static Action AddIgnoreExceptions(this Action action)
        {
            return () => action.IgnoreExceptions();
        }
    }
