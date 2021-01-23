    if (!ModelState.IsValid)
    {
        var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
    }
