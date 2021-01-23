    private static IDataGridColumnData GetDataGridColumnData(
        Type searchType, Type resultType)
    {
        var typedColumnDataType = typeof(DataGridColumnData<,>)
                .MakeGenericType(new[] { searchType, resultType });
        return (IDataGridColumnData)Activator.CreateInstance(typedColumnDataType);
    }
    
