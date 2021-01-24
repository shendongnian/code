    public int GetColumnMaxLength(EntityEntry entityEntry)
    {
        int result = 0;
        var table = entityEntry.Metadata.Model.FindEntityType(entityEntry.Metadata.ClrType);
        // Column info 
        foreach (var property in table.GetProperties())
        {
            var maxLength = property.GetMaxLength();
            // For sql info, e.g. ColumnType = nvarchar(255):
            var sqlInfo = property.SqlServer();
        };
        return result;
    }
