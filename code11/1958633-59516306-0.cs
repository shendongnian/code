    /// <summary>
    /// A function that can process a <see cref="TContext"/> dependent rule.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <param name="context"></param>
    /// <returns>A task that represents the completion of rule processing</returns>
    public delegate Task RuleHandlingDelegate<TContext>(TContext context);
    
