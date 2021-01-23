    public static class SearchContextExtensions
    {
        /// <summary>
        ///     Method that finds an element based on the search parameters within a specified timeout.
        /// </summary>
        /// <param name="context">The context where this is searched. Required for extension methods</param>
        /// <param name="by">The search parameters that are used to identify the element</param>
        /// <param name="timeOutInSeconds">The time that the tool should wait before throwing an exception</param>
        /// <returns> The first element found that matches the condition specified</returns>
        public static IWebElement FindElement(this ISearchContext context, By by, uint timeOutInSeconds)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new DefaultWait<ISearchContext>(context);
                wait.Timeout = TimeSpan.FromSeconds(timeOutInSeconds);
                return wait.Until<IWebElement>(ctx => ctx.FindElement(by));
            }
            return context.FindElement(by);
        }
        /// <summary>
        ///     Method that finds a list of elements based on the search parameters within a specified timeout.
        /// </summary>
        /// <param name="context">The context where this is searched. Required for extension methods</param>
        /// <param name="by">The search parameters that are used to identify the element</param>
        /// <param name="timeoutInSeconds">The time that the tool should wait before throwing an exception</param>
        /// <returns>A list of all the web elements that match the condition specified</returns>
        public static IReadOnlyCollection<IWebElement> FindElements(this ISearchContext context, By by, uint timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new DefaultWait<ISearchContext>(context);
                wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
                return wait.Until<IReadOnlyCollection<IWebElement>>(ctx => ctx.FindElements(by));
            }
            return context.FindElements(by);
        }
        /// <summary>
        ///     Method that finds a list of elements with the minimum amount specified based on the search parameters within a specified timeout.<br/>
        /// </summary>
        /// <param name="context">The context where this is searched. Required for extension methods</param>
        /// <param name="by">The search parameters that are used to identify the element</param>
        /// <param name="timeoutInSeconds">The time that the tool should wait before throwing an exception</param>
        /// <param name="minNumberOfElements">
        ///     The minimum number of elements that should meet the criteria before returning the list <para/>
        ///     If this number is not met, an exception will be thrown and no elements will be returned
        ///     even if some did meet the criteria
        /// </param>
        /// <returns>A list of all the web elements that match the condition specified</returns>
        public static IReadOnlyCollection<IWebElement> FindElements(this ISearchContext context, By by, uint timeoutInSeconds, int minNumberOfElements)
        {
            var wait = new DefaultWait<ISearchContext>(context);
            if (timeoutInSeconds > 0)
            {
                wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            }
            
            // Wait until the current context found the minimum number of elements. If not found after timeout, an exception is thrown
            wait.Until<bool>(ctx => ctx.FindElements(by).Count >= minNumberOfElements);
            
            //If the elements were successfuly found, just return the list
            return context.FindElements(by);
        }
    }
