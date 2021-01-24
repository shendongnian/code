    public Task DeleteColorSchemeAsync(ColorScheme colorScheme)
    {
        if (colorScheme == null)
            throw new ArgumentNullException(nameof(colorScheme));
    
        if (colorScheme.IsDefault)
            throw new SettingIsDefaultException();
    
        _dbContext.ColorSchemes.Remove(colorScheme);
        return _dbContext.SaveChangesAsync();
    }
