    [HttpPut]
    [Route("updatestates")]
    public async Task<IActionResult> UpdateStates(RedisServiceModel update) {
        RedisServiceModel updateState = await _redisService.UpdateStateAsync(update);
        if (updateState != null) {
            return Ok();
        }
        return StausCode((int)HttpStatusCode.NotModified);
    }
