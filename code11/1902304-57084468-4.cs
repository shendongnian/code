    /// <summary>
    /// Creates an <see cref="OkObjectResult"/> object that produces an <see cref="StatusCodes.Status200OK"/> response.
    /// </summary>
    /// <param name="value">The content value to format in the entity body.</param>
    /// <returns>The created <see cref="OkObjectResult"/> for the response.</returns>
    [NonAction]
    public virtual OkObjectResult Ok([ActionResultObjectValue] object value)
        => new OkObjectResult(value);
