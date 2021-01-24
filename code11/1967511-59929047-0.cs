    [Fact]
    public void DeleteMapShouldSetAuditFields()
    {
        var asset = new Asset();
        var cmd = new DeleteCommand
        {
            DeletedBy = Guid.NewGuid()
        };
    
        _mapper.Map(cmd, asset);
    
        Assert.NotNull(asset.DeletedBy);
        Assert.NotNull(asset.DeletedDate);
        Assert.Equal(cmd.DeletedBy, asset.DeletedBy);
    }
