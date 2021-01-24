     [HttpGet("{id}/recipes")]
        public async Task<IActionResult> GetUserWithRecipes (int id)
        {
            var user = await _repository.GetUserWithRecipes(id);
            var userToReturn = _mapper.Map<UserForRecipeDto>(user);
            return Ok(userToReturn);
        }
