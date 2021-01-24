    public Task DeleteColorSchemeAsync(ColorScheme colorScheme)
    {
        if (colorScheme == null)
            throw new ArgumentNullException(nameof(colorScheme));
    
        if (colorScheme.IsDefault)
            throw new SettingIsDefaultException();
    
        return DeleteColorSchemeInternalAsync(colorScheme);
    }
    
    private async Task DeleteColorSchemeInternalAsync(ColorScheme colorScheme)
    {
        _dbContext.ColorSchemes.Remove(colorScheme);
        await _dbContext.SaveChangesAsync();
    }
