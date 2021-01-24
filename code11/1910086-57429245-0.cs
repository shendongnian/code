    public async Task<IActionResult> ErrorHandlingWrapper<T>(Func<Task<T>> action)
    {
        try
        {
            //return action();
            return Ok(await action());
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
            return  StatusCode(500, ex.Message);
        }
    }
    [HttpPost("{custId}")]
    [Authorize]
    public async Task<IActionResult> GetCustomer(int custId)
    {
        return await ErrorHandlingWrapper(async () =>
                                    await _service.GetCustomer(custId)
                    );
    }
