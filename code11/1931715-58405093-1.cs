    if (!newSong.IsValid)
    {
        newSong.Validate().AddToModelState(ModelState, null);
        _logger.LogWarning("{method} failed model validation (ModelState: {@modelState}), returning Unprocessable Entity", nameof(Post), ModelState.Values.SelectMany(v => v.Errors));
        return ValidationProblem(ModelState);                
    }
