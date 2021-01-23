    public static DetailEditorColumn<int> Create(ColumnMetaData metaData, List<T> lookupList)
    {
        //what is coded above
        if (metaData.ColumnType == ColumnType.DropDownList)
        {
            if (lookupList == null)
                //handle error
            else
                return GridColumnBuilder<int>.GetDropDownListColumn(metaData.DisplayOrder, metaData, lookupList);
        }
    }
    
    public static DetailEditorColumn<int> Create(ColumnMetaData metaData)
    {
        return ClassName.Create(metaData, null);
    }
