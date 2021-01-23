    /// <summary>
    /// Creates an instance of <see cref="ITemplate"/> from the specified string template.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    /// <param name="razorTemplate">The string template.</param>
    /// <param name="model">The model instance.</param>
    /// <returns>An instance of <see cref="ITemplate"/>.</returns>
    ITemplate CreateTemplate<T>(string razorTemplate, T model);
