    /// <summary>
    /// Creates an <see cref="BadRequestObjectResult"/> that produces a <see cref="StatusCodes.Status400BadRequest"/> response.
    /// </summary>
    /// <param name="error">An error object to be returned to the client.</param>
    /// <returns>The created <see cref="BadRequestObjectResult"/> for the response.</returns>
    [NonAction]
    public virtual BadRequestObjectResult BadRequest([ActionResultObjectValue] object error)
        => new BadRequestObjectResult(error);
