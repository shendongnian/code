    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ValidateStuff(params)
    {
        if ( !await ValidateAsync(params) )
            return ValidationProblem( 
                new ValidationProblemDetails 
                { 
                    Detail = "params are invalid" 
                } );
        return NoContent();
    }
