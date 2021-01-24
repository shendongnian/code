        [AllowAnonymous]
        [HttpPost("authenticate")]
        [Route("{username}/{latitude}/{longitude}/{depth}/{corporationId}")]
        public async Task<IActionResult> Authenticate(string username, double latitude, double longitude, double depth, int corporationId)
        {
            try
            {
                // ...
                var result = await _repository.GetCalculationAsync(username, password, corporationId, latitude, longitude, depth);
                if (result == null) return Unauthorized();
                // Mapping
                // This centralizes all of the config
                var mappedResult = _mapper.Map<IEnumerable<CalculationModel>>(result);
                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
