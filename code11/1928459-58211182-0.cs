    [HttpGet("GetPets/{pageSize}/{pageIndex}/{keyWord?}")]
    public async Task<IActionResult> GetPets(int pageSize, int pageIndex, string keyWord = null)
    {
        var serviceResult = await _petService.GetPets(pageSize, pageIndex, keyWord);
        return Ok(serviceResult);
    }
