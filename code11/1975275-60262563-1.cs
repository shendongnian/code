    private List<TDto> ConvertUEntityToDto<TDto, TEntity>(IEnumerable<TEntity> entities)
    {
        var result = new List<TDto2>
        foreach (var entity in entities)
        {
            result.Add(_mapper.Map<TDto2>(entity));
        }
        return result;
    }
