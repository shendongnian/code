    // If no authorization header found, nothing to process further
    if (string.IsNullOrEmpty(authorization))
    {
        return AuthenticateResult.NoResult();
    }
>
    if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
    {
        token = authorization.Substring("Bearer ".Length).Trim();
    }
