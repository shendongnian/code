    [HttpGet]
    [Route("{customerId}")]
    public async Task<List<CategoryEntity>> GetCategoryByCustomerId(Guid customerId)
    {
        try
        {
            List<CategoryEntity> categoryEntities = _categoryRepository.GetAllCategoriesByCustomerId(customerId);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            return categoryEntities;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return null;
        }
    }
