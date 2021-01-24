    [HttpDelete("{userName}")]
    public async Task<IActionResult> Delete(string userName)
    {
        return await RemoveUser(userName);
    }
