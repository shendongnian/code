    // PUT api/category
    [HttpPut]
    public async Task Put([FromBody] CategoryDto categoryDto)
    {
         var category = _mapper.Map<Categories>(categoryDto);
         await _categoryService.UpdateCategory(category);
         // you probably want to set a response code. e.g return OK()
    }
