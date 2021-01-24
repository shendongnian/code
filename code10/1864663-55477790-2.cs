    /// <summary>
    /// Implictly converts the specified <paramref name="value"/> to an <see cref="ActionResult{TValue}"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator ActionResult<TValue>(TValue value)
    {
        return new ActionResult<TValue>(value);
    }
    /// <summary>
    /// Implictly converts the specified <paramref name="result"/> to an <see cref="ActionResult{TValue}"/>.
    /// </summary>
    /// <param name="result">The <see cref="ActionResult"/>.</param>
    public static implicit operator ActionResult<TValue>(ActionResult result)
    {
        return new ActionResult<TValue>(result);
    }
