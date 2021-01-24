    private List<TDto> ConvertUEntityToDto<TDto, TEntity>(IEnumerable<TEntity> entities)
    {
        var result = new List<TDto>
        foreach (var entity in entities)
        {
            result.Add(_mapper.Map<TDto>(entity));
        }
        return result;
    }
