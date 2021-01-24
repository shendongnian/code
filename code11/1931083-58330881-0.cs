    [HttpDelete]
    public async Task<ActionResult> Delete(Guid key)
    {
        ActionResult result;
        try
        {
           result = StatusCode(StatusCodes.Status200OK);
           await _repository.Delete<CodeKeyPairModel>(codeKeyPair);   
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fatal error deleting record key", ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
