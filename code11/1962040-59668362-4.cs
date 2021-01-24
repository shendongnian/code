    [HttpPut]
    [Route("updatestates")]
    public async Task<IActionResult> UpdateStates(RedisServiceModel update) {
        RedisServiceModel updateState = await _redisService.UpdateStateAsync(update);
        if (updateState != null) {
            return OK();
        }
        return NotModified();
    }
